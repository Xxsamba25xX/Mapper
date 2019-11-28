using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mapeador.Domain;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace Mapeador
{
	public partial class ProviderMapper : UserControl
	{

		private Dictionary<string, BaseMapping> BaseMapper { get; set; }
		private Dictionary<string, ProviderMapping> ProviderMapping { get; set; } = new Dictionary<string, ProviderMapping>();
		private AutoCompleteStringCollection ProviderSource { get; set; } = new AutoCompleteStringCollection();
		private AutoCompleteStringCollection OurSource { get; set; } = new AutoCompleteStringCollection();
		private bool TxtKeyUpdated { get; set; }
		private bool TxtOKeyUpdated { get; set; }
		private string Filename { get; set; } = "";
		private bool ModifyMode { get; set; } = false;
		private bool DeserializationSuccess { get; set; }

		public ProviderMapper()
		{
			InitializeComponent();
			StatusInit();
		}

		private void StatusInit()
		{
			ClearEdit();

			SetProviderSource();
			txtPKey.ReadOnly = false;
			txtPValue.ReadOnly = false;

			SetOurSource();
			txtOKey.ReadOnly = false;
			txtOValue.ReadOnly = true;

			txtJson.WordWrap = chkWordWrap.Checked;
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
					StatusFileLoaded();
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
			ProcessPKey();
			ProcessEditButtons();
		}

		private void txtKey_EnterLeave(object sender, EventArgs e)
		{
			if (TxtKeyUpdated)
			{
				TxtKeyUpdated = false;
				ProcessPKey();
				ProcessEditButtons();
			}
		}

		private void txtOKey_EnterLeave(object sender, EventArgs e)
		{
			if (TxtOKeyUpdated)
			{
				TxtOKeyUpdated = false;
				ProcessEditButtons();
			}
		}

		private void txtOKey_TextChanged(object sender, EventArgs e)
		{
			TxtOKeyUpdated = true;
			ProcessEditButtons();
		}

		private void btnOkEdit_Click(object sender, EventArgs e)
		{
			if (!VerifyEditFields()) return;

			var key = txtPKey?.Text?.Trim();
			ProviderMapping mapping = null;
			if (ModifyMode && ProviderMapping.ContainsKey(key))
			{
				mapping = ProviderMapping[key];
			}
			else if (!ModifyMode && !ProviderMapping.ContainsKey(key))
			{
				mapping = new ProviderMapping();
				mapping.ProviderElement.Key = key;
				ProviderMapping.Add(mapping.ProviderElement.Key, mapping);
			}

			if (mapping != null)
			{
				mapping.ProviderElement.Value = txtPValue?.Text?.Trim() ?? "";
				var ourKey = GetBaseKey(txtOKey?.Text);
				Ourelement ourelement = mapping.OurElements.FirstOrDefault(x => x.Key.Equals(ourKey, StringComparison.OrdinalIgnoreCase));
				if (ourelement == null)
				{
					ourelement = new Ourelement();
					ourelement.Key = ourKey;
					mapping.OurElements.Add(ourelement);
				}
				ourelement.Value = txtOValue?.Text?.Trim() ?? "";

				ClearEdit();
				ProviderMappingChanged();
			}
		}

		private void btnCancelEdit_Click(object sender, EventArgs e)
		{
			if (ModifyMode)
			{
				var key = txtPKey?.Text?.Trim();
				if (ProviderMapping.ContainsKey(key))
				{
					var mapping = ProviderMapping[key];
					mapping.OurElements.RemoveAll(x => x.Key == (txtOKey?.Text?.Trim() ?? ""));
					if (mapping.OurElements.Count == 0)
						ProviderMapping.Remove(key);
				}
			}
			ClearEdit();
			ProviderMappingChanged();
		}

		private void btnOkForm_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(Filename))
			{
				ProviderMapping = ProviderMapping ?? new Dictionary<string, ProviderMapping>();
				ClearEdit();
				ProviderMappingChanged();
				File.WriteAllText(Filename, txtJson.Text);
			}
		}

		private void btnCancelForm_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(Filename))
			{
				ClearEdit();
				StatusFileLoaded();
			}
		}

		//METHODS
		private void ClearEdit()
		{
			txtPKey.Text = "";
			txtPValue.Text = "";
			txtOKey.Text = "";
			txtOValue.Text = "";
			ModifyMode = false;
			ProcessEditButtons();
		}

		private void SetOurSource()
		{
			OurSource = OurSource ?? new AutoCompleteStringCollection();
			txtOKey.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtOKey.AutoCompleteSource = AutoCompleteSource.CustomSource;
			txtOKey.AutoCompleteCustomSource = OurSource;
		}

		private void SetProviderSource()
		{
			ProviderSource = ProviderSource ?? new AutoCompleteStringCollection();
			txtPKey.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			txtPKey.AutoCompleteSource = AutoCompleteSource.CustomSource;
			txtPKey.AutoCompleteCustomSource = ProviderSource;
		}

		private void PrepareDlgOpen()
		{
			dlgOpen.InitialDirectory = Application.StartupPath;
			dlgOpen.Filter = "JSON File (.json)|*.json";
			dlgOpen.FileName = "";
			dlgOpen.Title = "Select Base Mapping Json File";
		}

		private void StatusFileLoaded()
		{
			var baseMappingList = JsonConvert.DeserializeObject<ProviderMapping[]>(File.ReadAllText(Filename), CreateJsonSerializationSettings());
			if (DeserializationSuccess)
			{
				ProviderMapping = new Dictionary<string, ProviderMapping>();
				foreach (var item in baseMappingList)
				{
					ProviderMapping.Add(item.ProviderElement.Key, item);
				}
				ProviderMappingChanged();
			}
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

		private void ProviderMappingChanged()
		{
			FillJson();
			SetProviderSource();
			ProviderSource.Clear();
			ProviderSource.AddRange(ProviderMapping.Keys.ToArray());
		}

		private void FillJson()
		{
			double position = 0;
			if (txtJson.Text.Length > 0 && txtJson.SelectionStart > 0)
			{
				position = txtJson.SelectionStart / (double)(txtJson.Text.Length);
			}
			txtJson.Text = JsonConvert.SerializeObject(ProviderMapping.Values.OrderBy(x => x.ProviderElement.Key), Formatting.Indented);
			if (txtJson.Text.Length > 0)
			{
				txtJson.SelectionStart = (int)(txtJson.Text.Length * position);
			}
			txtJson.ScrollToCaret();
		}

		private void ProcessPKey()
		{
			var filter = txtPKey?.Text?.Trim();
			if (!string.IsNullOrWhiteSpace(filter))
			{
				if (ProviderMapping?.ContainsKey(filter) ?? false)
				{
					ModifyMode = true;
					txtPValue.Text = ProviderMapping[filter].ProviderElement.Value;
				}
				else
				{
					ModifyMode = false;
					txtPValue.Text = "";
				}
			}
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

		private string GetBaseKey(string possibleKey)
		{
			var result = possibleKey?.Trim() ?? "";

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

		private bool VerifyEditFields()
		{
			var pKey = txtPKey?.Text?.Trim() ?? "";
			var pValue = txtPValue?.Text?.Trim() ?? "";
			var oKey = GetBaseKey(txtOKey?.Text);
			var oValue = txtOValue?.Text?.Trim() ?? "";
			StringBuilder sb = new StringBuilder();
			string tab = "  ";
			if (string.IsNullOrWhiteSpace(pKey))
				sb.Append(tab).AppendLine("-PKey is Null, Empty or only contains Whitespaces.");

			if (string.IsNullOrWhiteSpace(oKey))
				sb.Append(tab).AppendLine("-OKey is Null, Empty or only contains Whitespaces.");
			if (!BaseMapper.ContainsKey(oKey))
				sb.Append(tab).AppendLine("-OKey doesn't exist in BaseMapping.");

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

		public void SetMapping(Dictionary<string, BaseMapping> mapping)
		{
			BaseMapper = mapping;
			SetOurSource();
			OurSource.Clear();
			OurSource.AddRange(BaseMapper.Keys.ToArray());
		}
	}
}
