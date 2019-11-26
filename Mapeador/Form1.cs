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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			baseMapper.OnMappingChanged += BaseMapper_OnMappingChanged;
		}

		private void BaseMapper_OnMappingChanged(object sender, Dictionary<string, Domain.BaseMapping> e)
		{
			if (providerMapper != null)
			{
				providerMapper.SetMapping(e);
			}
		}
	}
}
