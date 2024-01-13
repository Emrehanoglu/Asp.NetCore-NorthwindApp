using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public class SuccessDataResult<T>:DataResult<T>
	{
		public SuccessDataResult(T data, string message) : base(data, true, message) { }
		public SuccessDataResult(T data) : base(data, true) { }
		
		//aşağıdakileri proje boyunca kullanmayacağım ama kullanım şekli olarak data'nın
		//gelmediği durumlarda default yapısı bu şekilde kullanılıyor.
		//sırasıyla sadece durum ve sadece message gectıgım metotlar
		public SuccessDataResult() : base(default, true) { }
		public SuccessDataResult(string message) : base(default, true, message) { }
	}
}
