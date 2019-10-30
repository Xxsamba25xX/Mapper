using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeador.Domain
{
	public class BaseMapping
	{
		[JsonRequired]
		public string Key { get; set; }
		[JsonRequired]
		public string Link { get; set; }
		[JsonRequired]
		public string Latitude { get; set; }
		[JsonRequired]
		public string Longitude { get; set; }
	}
}
