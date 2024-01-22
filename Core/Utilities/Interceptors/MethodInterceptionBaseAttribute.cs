using Castle.Core.Interceptor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple =true, Inherited =true)]
	public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
	{
		public int Priority { get; set; }

		//metot farklı aspectlere hizmet edeceği için virtual olmalı
		public virtual void Intercept(IInvocation invocation)
		{
			//içi bos kalacak
		}
	}
}
