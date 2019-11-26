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
		private Dictionary<string, ProviderMapping> Mapping { get; set; } = new Dictionary<string, ProviderMapping>();
		private AutoCompleteStringCollection Source { get; set; } = new AutoCompleteStringCollection();
		private AutoCompleteStringCollection OurSource { get; set; } = new AutoCompleteStringCollection();
		private ProviderMapping SelectedMapping { get; set; } = new ProviderMapping();
		private bool TxtKeyUpdated { get; set; }
		private bool TxtOKeyUpdated { get; set; }
		private string Filename { get; set; } = "";
		private bool ModifyMode { get; set; } = false;
		private bool DeserializationSuccess { get; set; }

		public ProviderMapper()
		{
			InitializeComponent();
			txtPKey.AutoCompleteCustomSource = Source;
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

		private void btnOkEdit_Click(object sender, EventArgs e)
		{
			if (!VerifyEditFields()) return;

			var key = GetKey(txtPKey.Text);
			ProviderMapping mapping = null;
			if (ModifyMode && Mapping.ContainsKey(key))
			{
				mapping = Mapping[key];
			}
			else if (!ModifyMode && !Mapping.ContainsKey(key))
			{
				mapping = new ProviderMapping();
			}

			if (mapping != null)
			{
				mapping.ProviderElement.Key = key;
				mapping.ProviderElement.Value = txtPValue?.Text?.Trim() ?? "";
				var ourKey = txtOKey?.Text?.Trim() ?? "";
				Ourelement ourelement = mapping.OurElements.FirstOrDefault(x => x.Key.Equals(ourKey, StringComparison.OrdinalIgnoreCase));
				if (ourelement == null)
				{
					ourelement = new Ourelement();
					ourelement.Key = ourKey;
					mapping.OurElements.Add(ourelement);
				}
				ourelement.Value = txtOValue?.Text?.Trim() ?? "";

				if (!ModifyMode)
					Mapping.Add(mapping.ProviderElement.Key, mapping);

				EraseEdit();
				FillJson();
			}
		}

		private void btnCancelEdit_Click(object sender, EventArgs e)
		{
			if (ModifyMode)
			{
				var key = GetKey(txtPKey.Text);
				if (Mapping.ContainsKey(key))
				{
					var mapping = Mapping[key];
					mapping.OurElements.RemoveAll(x => x.Key == (txtOKey?.Text?.Trim() ?? ""));
					if (mapping.OurElements.Count == 0)
						Mapping.Remove(key);
				}
			}
			EraseEdit();
			FillJson();
		}

		private void btnOkForm_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(Filename))
			{
				Mapping = Mapping ?? new Dictionary<string, ProviderMapping>();
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

		private void txtOKey_EnterLeave(object sender, EventArgs e)
		{
			if (TxtOKeyUpdated)
			{
				ProcessOKey();
				TxtOKeyUpdated = false;
				ProcessEditButtons();
			}
		}

		private void txtOKey_TextChanged(object sender, EventArgs e)
		{
			TxtOKeyUpdated = true;
			ProcessOKey();
			ProcessEditButtons();
		}


		//METHODS
		private void EraseEdit()
		{
			txtPKey.Text = "";
			txtPValue.Text = "";
			txtOKey.Text = "";
			txtOValue.Text = "";
			ModifyMode = false;
			txtOKey.ReadOnly = true;
			txtOValue.ReadOnly = true;
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

		private void AutocompletedPKey(BaseMapping mapping)
		{
			txtPValue.Text = "";
			txtOKey.ReadOnly = false;
			txtOValue.ReadOnly = false;
			txtOKey.AutoCompleteCustomSource = OurSource;
			OurSource.Clear();
			if (Mapping.ContainsKey(mapping.Key))
			{
				OurSource.AddRange(Mapping[mapping.Key].OurElements.Select(x => x.Key).ToArray());
				SelectedMapping = Mapping[mapping.Key];
			}
		}

		private void AutocompletedOKey(Ourelement ourelement)
		{
			txtOValue.Text = ourelement.Value;
		}

		private void FillJson()
		{
			double position = 0;
			if (txtJson.Text.Length > 0 && txtJson.SelectionStart > 0)
			{
				position = txtJson.SelectionStart / (double)(txtJson.Text.Length);
			}
			txtJson.Text = JsonConvert.SerializeObject(Mapping.Values.OrderBy(x => x.ProviderElement.Key), Formatting.Indented);
			if (txtJson.Text.Length > 0)
			{
				txtJson.SelectionStart = (int)(txtJson.Text.Length * position);
			}
			txtJson.ScrollToCaret();
		}

		private void InsertItem(ProviderMapping item)
		{

		}

		private void OpenBaseMapping()
		{
			var baseMappingList = JsonConvert.DeserializeObject<ProviderMapping[]>(File.ReadAllText(Filename), CreateJsonSerializationSettings());
			if (DeserializationSuccess)
			{
				Mapping = new Dictionary<string, ProviderMapping>();
				foreach (var item in baseMappingList)
				{
					item.ProviderElement.Key = GetKey(item.ProviderElement.Key);
					Mapping.Add(item.ProviderElement.Key, item);
				}
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
			var filter = GetKey(txtPKey?.Text);
			if (!string.IsNullOrWhiteSpace(filter))
			{
				ModifyMode = BaseMapper?.Count > 0 && BaseMapper.ContainsKey(filter);
				if (ModifyMode)
				{
					AutocompletedPKey(BaseMapper[filter]);
				}
			}
		}

		private void ProcessOKey()
		{
			var filter = txtOKey?.Text;
			if (!string.IsNullOrWhiteSpace(filter))
			{
				var ourMapping = SelectedMapping.OurElements.FirstOrDefault(x => x.Key.Equals(filter, StringComparison.OrdinalIgnoreCase));
				if (ourMapping != null)
				{
					AutocompletedOKey(ourMapping);
				}
			}
		}

		private bool VerifyEditFields()
		{
			var pKey = txtPKey?.Text?.Trim() ?? "";
			var pValue = txtPValue?.Text?.Trim() ?? "";
			var oKey = txtOKey?.Text?.Trim() ?? "";
			var oValue = txtOValue?.Text?.Trim() ?? "";
			StringBuilder sb = new StringBuilder();
			Regex number = new Regex(@"^[-]?\d+([.]\d+)?$");
			string tab = "  ";
			if (string.IsNullOrWhiteSpace(pKey)) sb.Append(tab).AppendLine("-Key is Null, Empty or only contains Whitespaces.");

			if (string.IsNullOrWhiteSpace(oKey)) sb.Append(tab).AppendLine("-ProviderKey is Null, Empty or only contains Whitespaces.");

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

		public void SetMapping(Dictionary<string, BaseMapping> mapping)
		{
			BaseMapper = mapping;
			Source.Clear();
			Source.AddRange(mapping.Keys.ToArray());
		}
	}
}
