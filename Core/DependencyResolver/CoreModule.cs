using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolver
{
	public class CoreModule : ICoreModule
	{
		public void Load(IServiceCollection collection)
		{
			collection.AddMemoryCache();
			collection.AddSingleton<ICacheManager, MemoryCacheManager>();
			collection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			collection.AddSingleton<Stopwatch>();
		}
	}
}
