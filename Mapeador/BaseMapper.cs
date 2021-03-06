﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mapeador.Domain;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Diagnostics;
using WK.Libraries.SharpClipboardNS;

namespace Mapeador
{
	public partial class BaseMapper : UserControl
	{
		public event EventHandler<Dictionary<string, BaseMapping>> OnMappingChanged;


		private Dictionary<string, BaseMapping> Mapping { get; set; } = new Dictionary<string, BaseMapping>();
		private AutoCompleteStringCollection Source { get; set; } = new AutoCompleteStringCollection();
		private bool TxtKeyUpdated { get; set; }
		private string Filename { get; set; } = "";
		private string RegexLink { get; set; } = @"^(.+?)!3d(?<latitude>[-]?\d+?([.]\d+?)?)!4d(?<longitude>[-]?\d+?([.]\d+?)?)$";
		private bool ModifyMode { get; set; } = false;
		private bool DeserializationSuccess { get; set; }
		public string Key { get => rdKey.Text.Substring(0, rdKey.Text.Length - 1); set => rdKey.Text = value + ":"; }
		public string Link { get => rdLink.Text.Substring(0, rdLink.Text.Length - 1); set => rdLink.Text = value + ":"; }
		public string Lat { get => rdLat.Text.Substring(0, rdLat.Text.Length - 1); set => rdLat.Text = value + ":"; }
		public string Long { get => rdLong.Text.Substring(0, rdLong.Text.Length - 1); set => rdLong.Text = value + ":"; }

		public BaseMapper()
		{
			InitializeComponent();
		}

		//EVENTOS
		private void btnOpenJson_Click(object sender, EventArgs e)
		{
			PrepareDlgOpen();
			if (dlgOpen.ShowDialog() == DialogResult.OK)
			{
				if (File.Exists(dlgOpen.FileName))
				{
					Filename = dlgOpen.FileName;
					OpenBaseMapping();
				}
			}
		}

		private void chkWordWrap_CheckedChanged(object sender, EventArgs e)
		{
			txtJson.WordWrap = chkWordWrap.Checked;
		}

		private void txtKey_TextChanged(object sender, EventArgs e)
		{
			TxtKeyUpdated = true;
			ProcessKey();
			ProcessEditButtons();
		}

		private void txtKey_EnterLeave(object sender, EventArgs e)
		{
			if (TxtKeyUpdated)
			{
				ProcessKey();
				TxtKeyUpdated = false;
				ProcessEditButtons();
			}
		}

		private void txtLink_TextChanged(object sender, EventArgs e)
		{
			if (txtLink.Focused)
			{
				ProcessLink();
			}
		}

		private void btnOkEdit_Click(object sender, EventArgs e)
		{
			if (!VerifyEditFields()) return;

			var key = GetKey(txtKey.Text);
			BaseMapping mapping = null;
			if (ModifyMode && Mapping.ContainsKey(key))
			{
				mapping = Mapping[key];
			}
			else if (!ModifyMode && !Mapping.ContainsKey(key))
			{
				mapping = new BaseMapping();
			}

			if (mapping != null)
			{
				mapping.Key = key;
				mapping.Link = txtLink?.Text?.Trim() ?? "";
				mapping.Latitude = txtLat?.Text?.Trim() ?? "";
				mapping.Longitude = txtLong?.Text?.Trim() ?? "";

				if (!ModifyMode)
				{
					InsertItem(mapping);
					OnMappingChanged?.Invoke(this, Mapping);
				}

				EraseEdit();
				FillJson();
			}
		}

		private void btnCancelEdit_Click(object sender, EventArgs e)
		{
			if (ModifyMode)
			{
				var key = GetKey(txtKey.Text);
				if (Mapping.ContainsKey(key))
				{
					Mapping.Remove(key);
					OnMappingChanged?.Invoke(this, Mapping);
				}
			}
			EraseEdit();
			OnMappingChanged?.Invoke(this, Mapping);
			FillJson();
		}

		private void btnOkForm_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(Filename))
			{
				Mapping = Mapping ?? new Dictionary<string, BaseMapping>();
				OnMappingChanged?.Invoke(this, Mapping);
				FillJson();
				File.WriteAllText(Filename, txtJson.Text);
			}
		}

		private void btnCancelForm_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(Filename))
			{
				OpenBaseMapping();
			}
		}

		//METHODS
		private void EraseEdit()
		{
			txtKey.Text = "";
			txtLink.Text = "";
			txtLat.Text = "";
			txtLong.Text = "";
			ModifyMode = false;
			ProcessEditButtons();
		}

		private JsonSerializerSettings CreateJsonSerializationSettings()
		{
			var jsonSettings = new JsonSerializerSettings();
			DeserializationSuccess = true;
			jsonSettings.Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>((obj, evt) =>
			{
				DeserializationSuccess = false;
				evt.ErrorContext.Handled = true;
			});
			return jsonSettings;
		}

		private void AutocompletedKey(BaseMapping mapping)
		{
			txtLink.Text = mapping.Link;
			txtLat.Text = mapping.Latitude;
			txtLong.Text = mapping.Longitude;
		}

		private void FillJson()
		{
			double position = 0;
			if (txtJson.Text.Length > 0 && txtJson.SelectionStart > 0)
			{
				position = txtJson.SelectionStart / (double)(txtJson.Text.Length);
			}
			txtJson.Text = JsonConvert.SerializeObject(Mapping.Values.OrderBy(x => x.Key), Formatting.Indented);
			txtKey.AutoCompleteCustomSource = Source;
			if (txtJson.Text.Length > 0)
			{
				txtJson.SelectionStart = (int)(txtJson.Text.Length * position);
			}
			txtJson.ScrollToCaret();
		}

		private void InsertItem(BaseMapping item)
		{
			Mapping.Add(item.Key, item);
			Source.Add(item.Key);
		}

		private void OpenBaseMapping()
		{
			var baseMappingList = JsonConvert.DeserializeObject<BaseMapping[]>(File.ReadAllText(Filename), CreateJsonSerializationSettings());
			if (DeserializationSuccess)
			{
				Mapping = new Dictionary<string, BaseMapping>();
				Source = new AutoCompleteStringCollection();
				foreach (var item in baseMappingList)
				{
					item.Key = GetKey(item.Key);
					InsertItem(item);
				}

				OnMappingChanged?.Invoke(this, Mapping);
				FillJson();
			}
		}

		private void PrepareDlgOpen()
		{
			dlgOpen.InitialDirectory = Application.StartupPath;
			dlgOpen.Filter = "JSON File (.json)|*.json";
			dlgOpen.FileName = "";
			dlgOpen.Title = "Select Base Mapping Json File";
		}

		private void ProcessEditButtons()
		{
			if (ModifyMode)
			{
				tipBase.SetToolTip(btnCancelEdit, "Remove");
				tipBase.SetToolTip(btnOkEdit, "Update");
			}
			else
			{
				tipBase.SetToolTip(btnCancelEdit, "Cancel");
				tipBase.SetToolTip(btnOkEdit, "Insert");
			}
		}

		private void ProcessKey()
		{
			var filter = GetKey(txtKey?.Text);
			if (!string.IsNullOrWhiteSpace(filter))
			{
				ModifyMode = Mapping?.Count > 0 && Mapping.ContainsKey(filter);
				if (ModifyMode)
				{
					AutocompletedKey(Mapping[filter]);
				}
			}
		}

		private void ProcessLink()
		{
			var filter = txtLink?.Text?.Trim();
			if (!string.IsNullOrWhiteSpace(filter))
			{
				var match = Regex.Match(filter, RegexLink);
				var latitude = match.Groups["latitude"];
				var longitude = match.Groups["longitude"];
				if (match.Success && latitude.Success && longitude.Success)
				{
					txtLat.Text = latitude.Value;
					txtLong.Text = longitude.Value;
				}
			}
		}

		private bool VerifyEditFields()
		{
			var key = txtKey?.Text?.Trim() ?? "";
			var link = txtLink?.Text?.Trim() ?? "";
			var lat = txtLat?.Text?.Trim() ?? "";
			var lng = txtLong?.Text?.Trim() ?? "";
			StringBuilder sb = new StringBuilder();
			Regex number = new Regex(@"^[-]?\d+([.]\d+)?$");
			string tab = "  ";
			if (string.IsNullOrWhiteSpace(key)) sb.Append(tab).AppendLine("-Key is Null, Empty or only contains Whitespaces.");
			if (string.IsNullOrWhiteSpace(link)) sb.Append(tab).AppendLine("-Link is Null, Empty or only contains Whitespaces.");

			if (string.IsNullOrWhiteSpace(lat)) sb.Append(tab).AppendLine("-Latitude is Null, Empty or only contains Whitespaces.");
			else if (!number.IsMatch(lat)) sb.Append(tab).AppendLine("-Latitude MUST be a Numeric value.");

			if (string.IsNullOrWhiteSpace(lng)) sb.Append(tab).AppendLine("-Longitude is Null, Empty or only contains Whitespaces.");
			else if (!number.IsMatch(lng)) sb.Append(tab).AppendLine("-Longitude MUST be a Numeric value.");

			var result = sb.ToString();
			if (!string.IsNullOrWhiteSpace(result))
			{
				MessageBox.Show("There are some errors on your mapping!!!: \n" + result);
				return false;
			}
			else
			{
				return true;
			}
		}

		private string GetKey(string possibleKey)
		{
			var result = possibleKey?.Trim()?.ToLower() ?? "";

			result = Regex.Replace(result, @"[^\u0041-\u005A\u0061-\u007A\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u017E]+", "-");
			result = Regex.Replace(result, @"([-]|^)(?<letters>[a-zA-Z])", new MatchEvaluator(match =>
			{
				StringBuilder sb = new StringBuilder();

				var realMatch = match.Groups["letters"];
				if (realMatch.Success)
				{
					for (int i = match.Index; i < (match.Index + match.Length); i++)
					{
						var index = i - match.Index;
						if (i >= realMatch.Index && i < (realMatch.Index + realMatch.Length))
						{
							sb.Append(char.ToUpper(match.Value[index]));
						}
						else
						{
							sb.Append(char.ToLower(match.Value[index]));
						}
					}
				}
				return sb.ToString();
			}));
			result = result.Trim('-');
			return result;
		}

		private void chkSmart_CheckedChanged(object sender, EventArgs e)
		{

		}

		public  void EmuleClipboardChange(object sender, SharpClipboard.ClipboardChangedEventArgs e)
		{

			if (chkSmart.Checked)
			{
				if (  e?.Content != null)
				{
					var text = e.Content.ToString();
					if (!string.IsNullOrWhiteSpace(txtRegex.Text))
					{
						Regex regex = null;
						try
						{
							regex = new Regex(txtRegex.Text, RegexOptions.IgnoreCase);
						}
						catch (Exception) { }
						if (regex != null)
						{
							var match = regex.Match(text);
							if (match.Success)
							{
								var group = match.Groups[Key];
								if (group.Success)
									txtKey.Text = group.Value;
								group = match.Groups[Link];
								if (group.Success)
									txtLink.Text = group.Value;
								group = match.Groups[Lat];
								if (group.Success)
									txtLat.Text = group.Value;
								group = match.Groups[Long];
								if (group.Success)
									txtLong.Text = group.Value;
							}
						}
					}
				}
			}
		}
	}
}
