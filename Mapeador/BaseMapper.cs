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
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Mapeador
{
	public partial class BaseMapper : UserControl
	{

		public Dictionary<string, BaseMapping> Mapping { get; set; }
		private bool TxtKeyUpdated { get; set; }
		private string Filename { get; set; }
		private string RegexLink { get; set; } = @"^(https:\/\/www[.]google[.]com\/maps)(.+?)!3d(?<latitude>[-]?\d+?([.]\d+?)?)!4d(?<longitude>[-]?\d+?([.]\d+?)?)$";
		private bool ModifyMode { get; set; } = false;

		private Status status = Status.OK;
		public Status Status
		{
			get
			{
				return status;
			}
			private set
			{
				status = value;
				OnStatusChanged();
			}
		}


		public BaseMapper()
		{
			InitializeComponent();
		}

		private void BaseMapper_Load(object sender, EventArgs e)
		{

		}

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

		private void OpenBaseMapping()
		{
			var baseMappingList = JsonConvert.DeserializeObject<BaseMapping[]>(File.ReadAllText(Filename), CreateJsonSerializationSettings());
			if (Status != Status.SerializationError)
			{
				Mapping = new Dictionary<string, BaseMapping>();
				var source = new AutoCompleteStringCollection();
				foreach (var item in baseMappingList)
				{
					Mapping.Add(item.Key.ToUpper(), item);
					source.Add(item.Key);
				}

				txtJson.Text = JsonConvert.SerializeObject(Mapping.Values, Formatting.Indented);
				txtKey.AutoCompleteCustomSource = source;
			}
		}

		private JsonSerializerSettings CreateJsonSerializationSettings()
		{
			var jsonSettings = new JsonSerializerSettings();
			jsonSettings.Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>((obj, evt) =>
			{
				Status = Status.SerializationError;
				evt.ErrorContext.Handled = true;
			});
			return jsonSettings;
		}

		private void PrepareDlgOpen()
		{
			dlgOpen.InitialDirectory = Application.StartupPath;
			dlgOpen.Filter = "JSON File (.json)|*.json";
			dlgOpen.FileName = "";
			dlgOpen.Title = "Select Base Mapping Json File";
		}

		private void OnStatusChanged()
		{
			switch (status)
			{
				case Status.FileNotExist:
				case Status.SerializationError:
				case Status.Ready:
					txtKey.Enabled = false;
					txtLink.Enabled = false;
					txtLat.Enabled = false;
					txtLong.Enabled = false;
					btnCancelEdit.Enabled = false;
					btnOkEdit.Enabled = false;
					txtJson.Enabled = false;
					btnOkForm.Enabled = false;
					btnCancelForm.Enabled = false;
					chkSmart.Enabled = false;
					chkWordWrap.Enabled = false;
					break;
				case Status.OK:
					txtKey.Enabled = true;
					txtLink.Enabled = true;
					txtLat.Enabled = true;
					txtLong.Enabled = true;
					btnCancelEdit.Enabled = true;
					btnOkEdit.Enabled = true;
					txtJson.Enabled = true;
					btnOkForm.Enabled = true;
					btnCancelForm.Enabled = true;
					chkSmart.Enabled = true;
					chkWordWrap.Enabled = true;
					break;
				default:
					break;
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

		private void ProcessKey()
		{
			var filter = txtKey?.Text?.Trim()?.ToUpper();
			if (!string.IsNullOrWhiteSpace(filter))
			{
				ModifyMode = Mapping?.Count > 0 && Mapping.ContainsKey(filter);
				if (ModifyMode)
				{
					AutocompletedKey(Mapping[txtKey?.Text?.Trim()?.ToUpper()]);
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

		private void AutocompletedKey(BaseMapping mapping)
		{
			txtLink.Text = mapping.Link;
			txtLat.Text = mapping.Latitude;
			txtLong.Text = mapping.Longitude;
		}

		private void txtLink_TextChanged(object sender, EventArgs e)
		{
			if (txtLink.Focused)
			{
				ProcessLink();
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

		private void btnOkEdit_Click(object sender, EventArgs e)
		{
			//COMPLETAR
		}

		private void btnCancelEdit_Click(object sender, EventArgs e)
		{
			//COMPLETAR
		}
	}

	public enum Status
	{
		Ready = 0,
		OK = 1,
		SerializationError = 2,
		FileNotExist = 4

	}
}
