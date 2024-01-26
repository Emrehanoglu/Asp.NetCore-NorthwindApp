using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Performance
{
	public class PerformanceAspect:MethodInterception
	{
		private int _interval; //aralık bilgisi

		public PerformanceAspect(int interval)
		{
			_interval = interval;
			_stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
		}

		private Stopwatch _stopwatch; //kronometre görevi görecek
		protected override void OnBefore(IInvocation ınvocation)
		{
			//ilgili metot başladığında kronometreyi başlatmam gerekiyor
			_stopwatch.Start();
		}
		protected override void OnAfter(IInvocation ınvocation)
		{
			if(_stopwatch.Elapsed.TotalSeconds > _interval)
			{
				Debug.WriteLine($"Performance: {ınvocation.Method.DeclaringType.FullName}.{ınvocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
			}

			//ilgili metot bittiğinde kronometreyi durdurmam gerekiyor
			_stopwatch.Reset();
		}
	}
}
