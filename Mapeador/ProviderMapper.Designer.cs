namespace Mapeador
{
	partial class ProviderMapper
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
			this.txtJson = new System.Windows.Forms.RichTextBox();
			this.btnOpenJson = new System.Windows.Forms.Button();
			this.lblJson = new System.Windows.Forms.Label();
			this.txtOValue = new System.Windows.Forms.TextBox();
			this.txtOKey = new System.Windows.Forms.TextBox();
			this.txtPValue = new System.Windows.Forms.TextBox();
			this.txtPKey = new System.Windows.Forms.TextBox();
			this.lblLong = new System.Windows.Forms.Label();
			this.lblLat = new System.Windows.Forms.Label();
			this.btnOkForm = new System.Windows.Forms.Button();
			this.btnCancelForm = new System.Windows.Forms.Button();
			this.btnCancelEdit = new System.Windows.Forms.Button();
			this.btnOkEdit = new System.Windows.Forms.Button();
			this.tipBase = new System.Windows.Forms.ToolTip(this.components);
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.chkWordWrap = new System.Windows.Forms.CheckBox();
			this.chkSmart = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtRegex = new System.Windows.Forms.TextBox();
			this.rdKey = new System.Windows.Forms.RadioButton();
			this.rdValue = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// txtJson
			// 
			this.txtJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtJson.Location = new System.Drawing.Point(23, 224);
			this.txtJson.Name = "txtJson";
			this.txtJson.Size = new System.Drawing.Size(540, 294);
			this.txtJson.TabIndex = 35;
			this.txtJson.Text = "";
			// 
			// btnOpenJson
			// 
			this.btnOpenJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOpenJson.Location = new System.Drawing.Point(83, 195);
			this.btnOpenJson.Name = "btnOpenJson";
			this.btnOpenJson.Size = new System.Drawing.Size(75, 23);
			this.btnOpenJson.TabIndex = 34;
			this.btnOpenJson.Text = "Open";
			this.btnOpenJson.UseVisualStyleBackColor = true;
			this.btnOpenJson.Click += new System.EventHandler(this.btnOpenJson_Click);
			// 
			// lblJson
			// 
			this.lblJson.AutoSize = true;
			this.lblJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblJson.Location = new System.Drawing.Point(22, 198);
			this.lblJson.Margin = new System.Windows.Forms.Padding(10, 20, 10, 0);
			this.lblJson.Name = "lblJson";
			this.lblJson.Size = new System.Drawing.Size(53, 17);
			this.lblJson.TabIndex = 33;
			this.lblJson.Text = "JSON: ";
			// 
			// txtOValue
			// 
			this.txtOValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOValue.Location = new System.Drawing.Point(102, 141);
			this.txtOValue.Name = "txtOValue";
			this.txtOValue.ReadOnly = true;
			this.txtOValue.Size = new System.Drawing.Size(191, 20);
			this.txtOValue.TabIndex = 30;
			// 
			// txtOKey
			// 
			this.txtOKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtOKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtOKey.Location = new System.Drawing.Point(102, 104);
			this.txtOKey.Name = "txtOKey";
			this.txtOKey.ReadOnly = true;
			this.txtOKey.Size = new System.Drawing.Size(191, 20);
			this.txtOKey.TabIndex = 29;
			this.txtOKey.TextChanged += new System.EventHandler(this.txtOKey_TextChanged);
			this.txtOKey.Enter += new System.EventHandler(this.txtOKey_EnterLeave);
			this.txtOKey.Leave += new System.EventHandler(this.txtOKey_EnterLeave);
			// 
			// txtPValue
			// 
			this.txtPValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPValue.Location = new System.Drawing.Point(102, 68);
			this.txtPValue.Name = "txtPValue";
			this.txtPValue.ReadOnly = true;
			this.txtPValue.Size = new System.Drawing.Size(191, 20);
			this.txtPValue.TabIndex = 28;
			// 
			// txtPKey
			// 
			this.txtPKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtPKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.txtPKey.Location = new System.Drawing.Point(102, 30);
			this.txtPKey.Name = "txtPKey";
			this.txtPKey.Size = new System.Drawing.Size(191, 20);
			this.txtPKey.TabIndex = 27;
			this.txtPKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
			// 
			// lblLong
			// 
			this.lblLong.AutoSize = true;
			this.lblLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLong.Location = new System.Drawing.Point(22, 141);
			this.lblLong.Margin = new System.Windows.Forms.Padding(10, 20, 10, 0);
			this.lblLong.Name = "lblLong";
			this.lblLong.Size = new System.Drawing.Size(55, 17);
			this.lblLong.TabIndex = 26;
			this.lblLong.Text = "O. Val: ";
			// 
			// lblLat
			// 
			this.lblLat.AutoSize = true;
			this.lblLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLat.Location = new System.Drawing.Point(22, 104);
			this.lblLat.Margin = new System.Windows.Forms.Padding(10, 20, 10, 0);
			this.lblLat.Name = "lblLat";
			this.lblLat.Size = new System.Drawing.Size(55, 17);
			this.lblLat.TabIndex = 25;
			this.lblLat.Text = "O. Key:";
			// 
			// btnOkForm
			// 
			this.btnOkForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOkForm.BackColor = System.Drawing.Color.Lime;
			this.btnOkForm.BackgroundImage = global::Mapeador.Properties.Resources.OkBrush;
			this.btnOkForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnOkForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOkForm.Location = new System.Drawing.Point(488, 524);
			this.btnOkForm.Name = "btnOkForm";
			this.btnOkForm.Size = new System.Drawing.Size(75, 75);
			this.btnOkForm.TabIndex = 36;
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
			this.btnCancelForm.Location = new System.Drawing.Point(23, 524);
			this.btnCancelForm.Name = "btnCancelForm";
			this.btnCancelForm.Size = new System.Drawing.Size(75, 75);
			this.btnCancelForm.TabIndex = 37;
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
			this.btnCancelEdit.Location = new System.Drawing.Point(435, 31);
			this.btnCancelEdit.Name = "btnCancelEdit";
			this.btnCancelEdit.Size = new System.Drawing.Size(130, 130);
			this.btnCancelEdit.TabIndex = 32;
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
			this.btnOkEdit.Location = new System.Drawing.Point(299, 30);
			this.btnOkEdit.Name = "btnOkEdit";
			this.btnOkEdit.Size = new System.Drawing.Size(130, 130);
			this.btnOkEdit.TabIndex = 31;
			this.btnOkEdit.UseVisualStyleBackColor = false;
			this.btnOkEdit.Click += new System.EventHandler(this.btnOkEdit_Click);
			// 
			// dlgOpen
			// 
			this.dlgOpen.FileName = "openFileDialog1";
			// 
			// chkWordWrap
			// 
			this.chkWordWrap.AutoSize = true;
			this.chkWordWrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkWordWrap.Location = new System.Drawing.Point(166, 197);
			this.chkWordWrap.Margin = new System.Windows.Forms.Padding(5);
			this.chkWordWrap.Name = "chkWordWrap";
			this.chkWordWrap.Size = new System.Drawing.Size(99, 21);
			this.chkWordWrap.TabIndex = 38;
			this.chkWordWrap.Text = "Word Wrap";
			this.chkWordWrap.UseVisualStyleBackColor = true;
			this.chkWordWrap.CheckedChanged += new System.EventHandler(this.chkWordWrap_CheckedChanged);
			// 
			// chkSmart
			// 
			this.chkSmart.AutoSize = true;
			this.chkSmart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkSmart.Location = new System.Drawing.Point(166, 169);
			this.chkSmart.Margin = new System.Windows.Forms.Padding(5);
			this.chkSmart.Name = "chkSmart";
			this.chkSmart.Size = new System.Drawing.Size(114, 21);
			this.chkSmart.TabIndex = 39;
			this.chkSmart.Text = "Smart Copy ™";
			this.chkSmart.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label1.Location = new System.Drawing.Point(286, 200);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 17);
			this.label1.TabIndex = 41;
			this.label1.Text = "Regex:";
			// 
			// txtRegex
			// 
			this.txtRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRegex.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRegex.Location = new System.Drawing.Point(344, 199);
			this.txtRegex.Name = "txtRegex";
			this.txtRegex.Size = new System.Drawing.Size(219, 20);
			this.txtRegex.TabIndex = 40;
			// 
			// rdKey
			// 
			this.rdKey.AutoSize = true;
			this.rdKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.rdKey.Location = new System.Drawing.Point(25, 29);
			this.rdKey.Name = "rdKey";
			this.rdKey.Size = new System.Drawing.Size(71, 21);
			this.rdKey.TabIndex = 42;
			this.rdKey.TabStop = true;
			this.rdKey.Text = "P. Key:";
			this.rdKey.UseVisualStyleBackColor = true;
			// 
			// rdValue
			// 
			this.rdValue.AutoSize = true;
			this.rdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.rdValue.Location = new System.Drawing.Point(25, 67);
			this.rdValue.Name = "rdValue";
			this.rdValue.Size = new System.Drawing.Size(71, 21);
			this.rdValue.TabIndex = 43;
			this.rdValue.TabStop = true;
			this.rdValue.Text = "P. Val: ";
			this.rdValue.UseVisualStyleBackColor = true;
			// 
			// ProviderMapper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.rdValue);
			this.Controls.Add(this.rdKey);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRegex);
			this.Controls.Add(this.chkSmart);
			this.Controls.Add(this.chkWordWrap);
			this.Controls.Add(this.btnOkForm);
			this.Controls.Add(this.btnCancelForm);
			this.Controls.Add(this.txtJson);
			this.Controls.Add(this.btnOpenJson);
			this.Controls.Add(this.lblJson);
			this.Controls.Add(this.btnCancelEdit);
			this.Controls.Add(this.btnOkEdit);
			this.Controls.Add(this.txtOValue);
			this.Controls.Add(this.txtOKey);
			this.Controls.Add(this.txtPValue);
			this.Controls.Add(this.txtPKey);
			this.Controls.Add(this.lblLong);
			this.Controls.Add(this.lblLat);
			this.Name = "ProviderMapper";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(586, 611);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOkForm;
		private System.Windows.Forms.Button btnCancelForm;
		private System.Windows.Forms.RichTextBox txtJson;
		private System.Windows.Forms.Button btnOpenJson;
		private System.Windows.Forms.Label lblJson;
		private System.Windows.Forms.Button btnCancelEdit;
		private System.Windows.Forms.Button btnOkEdit;
		private System.Windows.Forms.TextBox txtOValue;
		private System.Windows.Forms.TextBox txtOKey;
		private System.Windows.Forms.TextBox txtPValue;
		private System.Windows.Forms.TextBox txtPKey;
		private System.Windows.Forms.Label lblLong;
		private System.Windows.Forms.Label lblLat;
		private System.Windows.Forms.ToolTip tipBase;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.CheckBox chkWordWrap;
		private System.Windows.Forms.CheckBox chkSmart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtRegex;
		private System.Windows.Forms.RadioButton rdKey;
		private System.Windows.Forms.RadioButton rdValue;
	}
}
