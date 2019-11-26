using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeador.Domain
{
	public class ProviderMapping
	{
		public ProviderElement ProviderElement { get; set; }
		public List<Ourelement> OurElements { get; set; } = new List<Ourelement>();
	}

	public class ProviderElement
	{
		public string Key { get; set; }
		public string Value { get; set; }
	}

	public class Ourelement
	{
		public string Key { get; set; }
		public string Value { get; set; }
	}


}
