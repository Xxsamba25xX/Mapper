namespace Mapeador
{
	partial class Form1
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.providerMapper = new Mapeador.ProviderMapper();
			this.baseMapper = new Mapeador.BaseMapper();
			this.clipboard = new WK.Libraries.SharpClipboardNS.SharpClipboard(this.components);
			this.SuspendLayout();
			// 
			// providerMapper
			// 
			this.providerMapper.Key = "Key";
			this.providerMapper.Location = new System.Drawing.Point(608, 12);
			this.providerMapper.Name = "providerMapper";
			this.providerMapper.Padding = new System.Windows.Forms.Padding(10);
			this.providerMapper.Size = new System.Drawing.Size(586, 694);
			this.providerMapper.TabIndex = 1;
			this.providerMapper.Value = "Val";
			// 
			// baseMapper
			// 
			this.baseMapper.Key = "Key";
			this.baseMapper.Lat = "Lat";
			this.baseMapper.Link = "Link";
			this.baseMapper.Location = new System.Drawing.Point(12, 12);
			this.baseMapper.Long = "Long";
			this.baseMapper.Name = "baseMapper";
			this.baseMapper.Padding = new System.Windows.Forms.Padding(10);
			this.baseMapper.Size = new System.Drawing.Size(600, 694);
			this.baseMapper.TabIndex = 0;
			// 
			// clipboard
			// 
			this.clipboard.MonitorClipboard = true;
			this.clipboard.ObservableFormats.All = false;
			this.clipboard.ObservableFormats.Files = false;
			this.clipboard.ObservableFormats.Images = false;
			this.clipboard.ObservableFormats.Others = false;
			this.clipboard.ObservableFormats.Texts = true;
			this.clipboard.ObserveLastEntry = true;
			this.clipboard.Tag = null;
			this.clipboard.ClipboardChanged += new System.EventHandler<WK.Libraries.SharpClipboardNS.SharpClipboard.ClipboardChangedEventArgs>(this.clipboard_ClipboardChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1206, 718);
			this.Controls.Add(this.providerMapper);
			this.Controls.Add(this.baseMapper);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private BaseMapper baseMapper;
		private ProviderMapper providerMapper;
		private WK.Libraries.SharpClipboardNS.SharpClipboard clipboard;
	}
}

