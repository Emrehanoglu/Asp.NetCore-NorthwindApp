using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolver
{
	public class CoreModule : ICoreModule
	{
		public void Load(IServiceCollection collection)
		{
			collection.AddMemoryCache();
		}
	}
}
