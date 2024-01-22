using Castle.Core.Interceptor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
	//bir metodun nerede nasıl yorumlanacağın bilineceği yer olacak
	public abstract class MethodInterception: MethodInterceptionBaseAttribute
	{
		protected virtual void OnBefore(IInvocation ınvocation) { } //metot çalışmadan once calısacak yer
		protected virtual void OnAfter(IInvocation ınvocation) { } //metot calıstıktan sonra calısacak yer
		protected virtual void OnException(IInvocation ınvocation) { } //metot hata verirse calısacak yer
		protected virtual void OnSuccess(IInvocation ınvocation) { } //metot başarılı calısırsa calısacak yer
		
		public override void Intercept(IInvocation invocation)
		{
			var isSuccess = true;
			OnBefore(invocation);
			try
			{
				invocation.Proceed();
			}
			catch (Exception)
			{
				isSuccess = false;
				OnException(invocation);
				throw;
			}
			finally
			{
				if (isSuccess)
				{
					OnSuccess(invocation);
				}
			}
			OnAfter(invocation);
		}
	}
}
