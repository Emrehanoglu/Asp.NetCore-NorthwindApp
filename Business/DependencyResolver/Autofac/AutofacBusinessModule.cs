﻿using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolver.Autofac
{
	public class AutofacBusinessModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ProductManager>().As<IProductService>(); // IProductService istenirse ona ProductManager verilecek.
			builder.RegisterType<EfProductDal>().As<IProductDal>(); // IProductDal istenirse ona EfProductDal verilecek.
			builder.RegisterType<CategoryManager>().As<ICategoryService>();
			builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
		}
	}
}
