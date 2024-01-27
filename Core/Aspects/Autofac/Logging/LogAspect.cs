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
				throw new System.Exception(AspectMessages.WrongLoggerType);
			}
			_loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
		}

		protected override void OnBefore(IInvocation ınvocation)
		{
			_loggerServiceBase.Info(GetLogDetail(ınvocation));
		}
		private LogDetail GetLogDetail(IInvocation ınvocation)
		{
			var logParameters = new List<LogParameter>();
			for (int i = 0; i < ınvocation.Arguments.Length; i++)
			{
				logParameters.Add(new LogParameter
				{
					Name = ınvocation.GetConcreteMethod().GetParameters()[i].Name,
					Value = ınvocation.Arguments[i],
					Type = ınvocation.Arguments[i].GetType().Name
				});
			}

			var logDetail = new LogDetail 
			{
				MethodName = ınvocation.Method.Name,
				LogParameters = logParameters
			};

			return logDetail;
		}
	}
}
