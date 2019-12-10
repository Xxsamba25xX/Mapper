using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapeador
{
	public partial class StringDialogBox : Form
	{
		public string Value
		{
			get
			{
				return txtResult?.Text ?? "";
			}
			set
			{
				if (txtResult != null && value != null)
					txtResult.Text = value;
			}
		}

		public string Message
		{
			get
			{
				return lblMessage?.Text ?? "";
			}
			set
			{
				if (lblMessage != null && value != null)
					lblMessage.Text = value;
			}
		}

		public string Title
		{
			get
			{
				return this?.Title ?? "";
			}
			set
			{
				if (this?.Title != null && value != null)
					this.Title = value;
			}
		}

		public StringDialogBox()
		{
			InitializeComponent();
		}

		private void StringDialogBox_Load(object sender, EventArgs e)
		{
		}

		private void lblMessage_SizeChanged(object sender, EventArgs e)
		{
			this.Width = lblMessage.Width + Math.Max(lblMessage.Margin.Left, this.Padding.Left) + Math.Max(lblMessage.Margin.Left, this.Padding.Left);
			var difHeight = lblMessage.Size.Height - lblMessage.MinimumSize.Height;
			this.Height = MinimumSize.Height + difHeight;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			txtResult.Text = "";
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
