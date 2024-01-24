using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
	public interface ICacheManager
	{
		T Get<T>(string key); //cache okuma
		object Get(string key); //cache okuma
		void Add(string key, object data, int duration); //cache ekleme
		bool IsAdd(string key); //cache eklenmişmi
		void Remove(string key); //cache 'in kaldırılmasını sağlar
		void RemoveByPattern(string pattern);
	}
}
