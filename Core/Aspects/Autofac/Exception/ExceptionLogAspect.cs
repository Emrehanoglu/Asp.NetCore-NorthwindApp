using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Messages;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Aspects.Autofac.Exception
{
	public class ExceptionLogAspect:MethodInterception
	{
		private LoggerServiceBase _loggerServiceBase;

		public ExceptionLogAspect(Type loggerService)
		{
			//DatabaseLogger veya FileLogger değil ise
			if (loggerService.BaseType != typeof(LoggerServiceBase))
			{
				throw new System.Exception(AspectMessages.WrongLoggerType);
			}

			_loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
		}

		protected override void OnException(IInvocation ınvocation)
		{
			base.OnException(ınvocation);
		}
	}
}
