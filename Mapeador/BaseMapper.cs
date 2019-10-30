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

namespace Mapeador
{
	public partial class BaseMapper : UserControl
	{

		public Dictionary<string, BaseMapping> Mapping { get; set; }
		private string Filename { get; set; }

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
				Mapping = baseMappingList.ToDictionary(x => x.Key, x => x);
				txtJson.Text = JsonConvert.SerializeObject(Mapping.Values, Formatting.Indented);
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
	}

	public enum Status
	{
		Ready = 0,
		OK = 1,
		SerializationError = 2,
		FileNotExist = 4

	}
}
