using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
	public static class BusinessRules
	{
		//burası Business katmanındaki iş kurallarını calıstırır
		public static IResult Run(params IResult[] logics)
		{
			foreach(var result in logics)
			{
				//iş kuralından gecemediyse
				if (!result.Success)
				{
					return result;
				}
			}
			//iş kurallarının hepsinden gecerse
			return null;
		}
	}
}
