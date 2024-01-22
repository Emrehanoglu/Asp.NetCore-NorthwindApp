using Castle.Core.Interceptor;
using Core.CrossCuttingConcerns.Validation;
using Core.Messages;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
	public class ValidationAspect:MethodInterception
	{
		private Type _validatorType;
		public ValidationAspect(Type validatorType)
		{
			if (!typeof(IValidator).IsAssignableFrom(validatorType))
			{
				//gonderilen validatorType, IValidator türünde değil ise
				throw new Exception(AspectMessages.WrongValidationType);
			}
			//öyleyse atamasını yapabilirim
			_validatorType = validatorType;
		}
		protected override void OnBefore(IInvocation invocation)
		{
			//base.OnBefore(ınvocation); //base 'deli OnBefore 'un içi zaten boş burası işime yaramaz.
			var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection yontemi ile instance türettim
			var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Product tür bilgisi elimde artık
			var entites = invocation.Arguments.Where(t => t.GetType() == entityType);
			foreach(var entity in entites)
			{
				ValidationTool.Validate(validator,entity);
			}
		}
	}
}
