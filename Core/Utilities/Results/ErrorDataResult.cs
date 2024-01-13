using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public class ErrorDataResult<T>:DataResult<T>
	{
		public ErrorDataResult(T data, string message) : base(data, false, message) { }
		public ErrorDataResult(T data) : base(data, false) { }

		//aşağıdakileri proje boyunca kullanmayacağım ama kullanım şekli olarak data'nın
		//gelmediği durumlarda default yapısı bu şekilde kullanılıyor.
		//sırasıyla sadece durum ve sadece message gectıgım metotlar
		public ErrorDataResult() : base(default, false) { }
		public ErrorDataResult(string message) : base(default, false, message) { }
	}
}
