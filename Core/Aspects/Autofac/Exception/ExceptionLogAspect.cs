using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
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

		protected override void OnException(IInvocation ınvocation, System.Exception e)
		{
			LogDetailWithException logDetailWithException = GetLogDetail(ınvocation);
			logDetailWithException.ExceptionMessage = e.Message;
			_loggerServiceBase.Error(logDetailWithException);
		}

		private LogDetailWithException GetLogDetail(IInvocation ınvocation)
		{
			var logParameters = new List<LogParameter>();
			
			for(int i = 0; i < ınvocation.Arguments.Length; i++)
			{
				logParameters.Add(new LogParameter
				{
					Name=ınvocation.GetConcreteMethod().GetParameters()[i].Name,
					Value=ınvocation.Arguments[i],
					Type=ınvocation.Arguments[i].GetType().Name
				});
			}

			var logDetailWithException = new LogDetailWithException
			{
				MethodName = ınvocation.Method.Name,
				LogParameters = logParameters
			};

			return logDetailWithException;
		}
	}
}
