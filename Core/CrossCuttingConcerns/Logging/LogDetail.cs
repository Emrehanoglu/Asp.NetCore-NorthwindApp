using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
	//log daki detay bilgisini tutacak
	public class LogDetail
	{
		public string MethodName { get; set; }
		public List<LogParameter> LogParameters { get; set; }
	}
}
