using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Messages;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Logging
{
	public class LogAspect:MethodInterception
	{
		//loglamayı ne zaman yapacağım onu burada belirtiyorum.
		private LoggerServiceBase _loggerServiceBase;

		public LogAspect(Type loggerService)
		{
			if(loggerService.BaseType != typeof(LoggerServiceBase))
			{
				throw new Exception(AspectMessages.WrongLoggerType);
			}
			_loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
		}

		protected override void OnBefore(IInvocation ınvocation)
		{
			_loggerServiceBase.Info(GetLogDetail(ınvocation));
		}
		private LogDetail GetLogDetail(IInvocation ınvocation)
		{
			var logParameters = ınvocation.Arguments.Select(x => new LogParameter
			{
				Value = x,
				Type = x.GetType().Name
			}).ToList();

			var logDetail = new LogDetail 
			{
				MethodName = ınvocation.Method.Name,
				LogParameters = logParameters
			};

			return logDetail;
		}
	}
}
