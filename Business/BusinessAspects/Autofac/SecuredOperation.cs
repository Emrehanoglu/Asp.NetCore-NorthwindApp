using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
	public class SecuredOperation:MethodInterception
	{
		private string[] _roles;
		private IHttpContextAccessor _httpContextAccessor;
		public SecuredOperation(string roles)
		{
			_roles = roles.Split(',');
			_httpContextAccessor =  ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
		}

		//ilgili operasyon baslamadan once calısacak.
		protected override void OnBefore(IInvocation ınvocation)
		{
			var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
			foreach(var role in roleClaims)
			{
				if (roleClaims.Contains(role))
				{
					//aradığım rol var dönebilirim
					return;
				}
			}
			//aradığım rol yok ise yani return olmamışsa
			throw new Exception(Messages.AuthorizationDenied);
		}
	}
}
