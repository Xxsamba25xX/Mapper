namespace Mapeador
{
	partial class BaseMapper
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.txtLink = new System.Windows.Forms.TextBox();
			this.txtLat = new System.Windows.Forms.TextBox();
			this.txtLong = new System.Windows.Forms.TextBox();
			this.lblJson = new System.Windows.Forms.Label();
			this.btnOpenJson = new System.Windows.Forms.Button();
			this.txtJson = new System.Windows.Forms.RichTextBox();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.chkSmart = new System.Windows.Forms.CheckBox();
			this.chkWordWrap = new System.Windows.Forms.CheckBox();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.tipBase = new System.Windows.Forms.ToolTip(this.components);
			this.btnOkForm = new System.Windows.Forms.Button();
			this.btnCancelForm = new System.Windows.Forms.Button();
			this.btnCancelEdit = new System.Windows.Forms.Button();
			this.btnOkEdit = new System.Windows.Forms.Button();
			this.rdKey = new System.Windows.Forms.RadioButton();
			this.rdLink = new System.Windows.Forms.RadioButton();
			this.rdLat = new System.Windows.Forms.RadioButton();
			this.rdLong = new System.Windows.Forms.RadioButton();
			this.txtRegex = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtLink
			// 
			this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLink.Location = new System.Drawing.Point(91, 67);
			this.txtLink.Name = "txtLink";
			this.txtLink.Size = new System.Drawing.Size(206, 20);
			this.txtLink.TabIndex = 9;
			this.txtLink.TextChanged += new System.EventHandler(this.txtLink_TextChanged);
			// 
			// txtLat
			// 
			this.txtLat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLat.Location = new System.Drawing.Point(91, 103);
			this.txtLat.Name = "txtLat";
			this.txtLat.Size = new System.Drawing.Size(206, 20);
			this.txtLat.TabIndex = 10;
			// 
			// txtLong
			// 
			this.txtLong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLong.Location = new System.Drawing.Point(91, 140);
			this.txtLong.Name = "txtLong";
			this.txtLong.Size = new System.Drawing.Size(206, 20);
			this.txtLong.TabIndex = 11;
			// 
			// lblJson
			// 
			this.lblJson.AutoSize = true;
			this.lblJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblJson.Location = new System.Drawing.Point(20, 198);
			this.lblJson.Margin = new System.Windows.Forms.Padding(10, 40, 10, 0);
			this.lblJson.Name = "lblJson";
			this.lblJson.Size = new System.Drawing.Size(53, 17);
			this.lblJson.TabIndex = 16;
			this.lblJson.Text = "JSON: ";
			// 
			// btnOpenJson
			// 
			this.btnOpenJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOpenJson.Location = new System.Drawing.Point(86, 194);
			this.btnOpenJson.Name = "btnOpenJson";
			this.btnOpenJson.Size = new System.Drawing.Size(75, 23);
			this.btnOpenJson.TabIndex = 17;
			this.btnOpenJson.Text = "Open";
			this.btnOpenJson.UseVisualStyleBackColor = true;
			this.btnOpenJson.Click += new System.EventHandler(this.btnOpenJson_Click);
			// 
			// txtJson
			// 
			this.txtJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtJson.Location = new System.Drawing.Point(23, 223);
			this.txtJson.Name = "txtJson";
			this.txtJson.Size = new System.Drawing.Size(554, 333);
			this.txtJson.TabIndex = 18;
			this.txtJson.Text = "";
			// 
			// dlgOpen
			// 
			this.dlgOpen.FileName = "openFileDialog1";
			// 
			// chkSmart
			// 
			this.chkSmart.AutoSize = true;
			this.chkSmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkSmart.Location = new System.Drawing.Point(169, 168);
			this.chkSmart.Margin = new System.Windows.Forms.Padding(5);
			this.chkSmart.Name = "chkSmart";
			this.chkSmart.Size = new System.Drawing.Size(114, 21);
			this.chkSmart.TabIndex = 23;
			this.chkSmart.Text = "Smart Copy ™";
			this.chkSmart.UseVisualStyleBackColor = true;
			this.chkSmart.CheckedChanged += new System.EventHandler(this.chkSmart_CheckedChanged);
			// 
			// chkWordWrap
			// 
			this.chkWordWrap.AutoSize = true;
			this.chkWordWrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkWordWrap.Location = new System.Drawing.Point(169, 197);
			this.chkWordWrap.Margin = new System.Windows.Forms.Padding(5);
			this.chkWordWrap.Name = "chkWordWrap";
			this.chkWordWrap.Size = new System.Drawing.Size(99, 21);
			this.chkWordWrap.TabIndex = 24;
			this.chkWordWrap.Text = "Word Wrap";
			this.chkWordWrap.UseVisualStyleBackColor = true;
			this.chkWordWrap.CheckedChanged += new System.EventHandler(this.chkWordWrap_CheckedChanged);
			// 
			// txtKey
			// 
			this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtKey.Location = new System.Drawing.Point(91, 29);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(206, 20);
			this.txtKey.TabIndex = 8;
			this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			this.txtKey.Enter += new System.EventHandler(this.txtKey_EnterLeave);
			this.txtKey.Leave += new System.EventHandler(this.txtKey_EnterLeave);
			// 
			// tipBase
			// 
			this.tipBase.AutomaticDelay = 100;
			// 
			// btnOkForm
			// 
			this.btnOkForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOkForm.BackColor = System.Drawing.Color.Lime;
			this.btnOkForm.BackgroundImage = global::Mapeador.Properties.Resources.OkBrush;
			this.btnOkForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnOkForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOkForm.Location = new System.Drawing.Point(502, 562);
			this.btnOkForm.Name = "btnOkForm";
			this.btnOkForm.Size = new System.Drawing.Size(75, 75);
			this.btnOkForm.TabIndex = 21;
			this.tipBase.SetToolTip(this.btnOkForm, "Save");
			this.btnOkForm.UseVisualStyleBackColor = false;
			this.btnOkForm.Click += new System.EventHandler(this.btnOkForm_Click);
			// 
			// btnCancelForm
			// 
			this.btnCancelForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancelForm.BackColor = System.Drawing.Color.Pink;
			this.btnCancelForm.BackgroundImage = global::Mapeador.Properties.Resources.ErrorBrush;
			this.btnCancelForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCancelForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelForm.Location = new System.Drawing.Point(23, 562);
			this.btnCancelForm.Name = "btnCancelForm";
			this.btnCancelForm.Size = new System.Drawing.Size(75, 75);
			this.btnCancelForm.TabIndex = 22;
			this.tipBase.SetToolTip(this.btnCancelForm, "Reset File");
			this.btnCancelForm.UseVisualStyleBackColor = false;
			this.btnCancelForm.Click += new System.EventHandler(this.btnCancelForm_Click);
			// 
			// btnCancelEdit
			// 
			this.btnCancelEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelEdit.BackColor = System.Drawing.Color.Pink;
			this.btnCancelEdit.BackgroundImage = global::Mapeador.Properties.Resources.ErrorBrush;
			this.btnCancelEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelEdit.Location = new System.Drawing.Point(439, 30);
			this.btnCancelEdit.Name = "btnCancelEdit";
			this.btnCancelEdit.Size = new System.Drawing.Size(130, 130);
			this.btnCancelEdit.TabIndex = 14;
			this.tipBase.SetToolTip(this.btnCancelEdit, "Cancel");
			this.btnCancelEdit.UseVisualStyleBackColor = false;
			this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
			// 
			// btnOkEdit
			// 
			this.btnOkEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOkEdit.BackColor = System.Drawing.Color.Lime;
			this.btnOkEdit.BackgroundImage = global::Mapeador.Properties.Resources.OkBrush;
			this.btnOkEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnOkEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOkEdit.Location = new System.Drawing.Point(303, 29);
			this.btnOkEdit.Name = "btnOkEdit";
			this.btnOkEdit.Size = new System.Drawing.Size(130, 130);
			this.btnOkEdit.TabIndex = 12;
			this.tipBase.SetToolTip(this.btnOkEdit, "Insert");
			this.btnOkEdit.UseVisualStyleBackColor = false;
			this.btnOkEdit.Click += new System.EventHandler(this.btnOkEdit_Click);
			// 
			// rdKey
			// 
			this.rdKey.AutoSize = true;
			this.rdKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.rdKey.Location = new System.Drawing.Point(23, 28);
			this.rdKey.Name = "rdKey";
			this.rdKey.Size = new System.Drawing.Size(54, 21);
			this.rdKey.TabIndex = 25;
			this.rdKey.Text = "Key:";
			this.rdKey.UseVisualStyleBackColor = true;
			// 
			// rdLink
			// 
			this.rdLink.AutoSize = true;
			this.rdLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.rdLink.Location = new System.Drawing.Point(23, 66);
			this.rdLink.Name = "rdLink";
			this.rdLink.Size = new System.Drawing.Size(56, 21);
			this.rdLink.TabIndex = 26;
			this.rdLink.Text = "Link:";
			this.rdLink.UseVisualStyleBackColor = true;
			// 
			// rdLat
			// 
			this.rdLat.AutoSize = true;
			this.rdLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.rdLat.Location = new System.Drawing.Point(23, 102);
			this.rdLat.Name = "rdLat";
			this.rdLat.Size = new System.Drawing.Size(50, 21);
			this.rdLat.TabIndex = 27;
			this.rdLat.Text = "Lat:";
			this.rdLat.UseVisualStyleBackColor = true;
			// 
			// rdLong
			// 
			this.rdLong.AutoSize = true;
			this.rdLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.rdLong.Location = new System.Drawing.Point(23, 139);
			this.rdLong.Name = "rdLong";
			this.rdLong.Size = new System.Drawing.Size(62, 21);
			this.rdLong.TabIndex = 28;
			this.rdLong.Text = "Long:";
			this.rdLong.UseVisualStyleBackColor = true;
			// 
			// txtRegex
			// 
			this.txtRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRegex.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRegex.Location = new System.Drawing.Point(358, 197);
			this.txtRegex.Name = "txtRegex";
			this.txtRegex.Size = new System.Drawing.Size(219, 20);
			this.txtRegex.TabIndex = 29;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label1.Location = new System.Drawing.Point(300, 198);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 17);
			this.label1.TabIndex = 30;
			this.label1.Text = "Regex:";
			// 
			// BaseMapper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRegex);
			this.Controls.Add(this.rdLong);
			this.Controls.Add(this.rdLat);
			this.Controls.Add(this.rdLink);
			this.Controls.Add(this.rdKey);
			this.Controls.Add(this.chkWordWrap);
			this.Controls.Add(this.chkSmart);
			this.Controls.Add(this.btnOkForm);
			this.Controls.Add(this.btnCancelForm);
			this.Controls.Add(this.txtJson);
			this.Controls.Add(this.btnOpenJson);
			this.Controls.Add(this.lblJson);
			this.Controls.Add(this.btnCancelEdit);
			this.Controls.Add(this.btnOkEdit);
			this.Controls.Add(this.txtLong);
			this.Controls.Add(this.txtLat);
			this.Controls.Add(this.txtLink);
			this.Controls.Add(this.txtKey);
			this.Name = "BaseMapper";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(600, 650);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.TextBox txtLink;
		private System.Windows.Forms.TextBox txtLat;
		private System.Windows.Forms.TextBox txtLong;
		private System.Windows.Forms.Button btnOkEdit;
		private System.Windows.Forms.Button btnCancelEdit;
		private System.Windows.Forms.Label lblJson;
		private System.Windows.Forms.Button btnOpenJson;
		private System.Windows.Forms.RichTextBox txtJson;
		private System.Windows.Forms.Button btnOkForm;
		private System.Windows.Forms.Button btnCancelForm;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.CheckBox chkSmart;
		private System.Windows.Forms.CheckBox chkWordWrap;
		private System.Windows.Forms.ToolTip tipBase;
		private System.Windows.Forms.RadioButton rdKey;
		private System.Windows.Forms.RadioButton rdLink;
		private System.Windows.Forms.RadioButton rdLat;
		private System.Windows.Forms.RadioButton rdLong;
		private System.Windows.Forms.TextBox txtRegex;
		private System.Windows.Forms.Label label1;
	}
}
