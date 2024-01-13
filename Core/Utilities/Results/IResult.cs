using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
	public interface IResult
	{
		bool Success { get; } //işlem başarılı mı, burası sadece readonly olacak
		string Message { get; } // işlemin acıklaması
	}
}
