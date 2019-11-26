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
			this.providerMapper = new Mapeador.ProviderMapper();
			this.baseMapper = new Mapeador.BaseMapper();
			this.SuspendLayout();
			// 
			// providerMapper
			// 
			this.providerMapper.Location = new System.Drawing.Point(608, 12);
			this.providerMapper.Name = "providerMapper";
			this.providerMapper.Padding = new System.Windows.Forms.Padding(10);
			this.providerMapper.Size = new System.Drawing.Size(586, 694);
			this.providerMapper.TabIndex = 1;
			// 
			// baseMapper
			// 
			this.baseMapper.Location = new System.Drawing.Point(12, 12);
			this.baseMapper.Name = "baseMapper";
			this.baseMapper.Padding = new System.Windows.Forms.Padding(10);
			this.baseMapper.Size = new System.Drawing.Size(600, 694);
			this.baseMapper.TabIndex = 0;
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
	}
}

