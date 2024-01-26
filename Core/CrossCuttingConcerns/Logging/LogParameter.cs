using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
	//loglanacak operasyondaki parametreler ve değerlerini tutacak.
	public class LogParameter
	{
		public string Name { get; set; }
		public object Value { get; set; }
		public string Type { get; set; }
	}
}
