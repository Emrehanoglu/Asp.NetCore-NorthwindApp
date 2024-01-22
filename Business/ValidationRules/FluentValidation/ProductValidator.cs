using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(p=>p.ProductName).NotEmpty(); //bos gecilemez
			RuleFor(p=>p.ProductName).Length(2, 30); //en az 2 en fazla 30 karakter olabilir
			RuleFor(p=>p.UnitPrice).NotEmpty();
			RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1); //en az 1 olmalı
			RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryId==1);
			RuleFor(p => p.ProductName).Must(StartWithA);
		}

		private bool StartWithA(string arg)
		{
			return arg.StartsWith("A");
		}
	}
}
