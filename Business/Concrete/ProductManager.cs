using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		private IProductDal _productDal;
		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		[ValidationAspect(typeof(ProductValidator))]
		[CacheRemoveAspect("IProductService.Get")]
		public IResult Add(Product product)
		{
			//ValidationTool.Validate(new ProductValidator(), product);

			_productDal.Add(product);
			return new SuccessResult(Messages.ProductAdded);
		}

		public IResult Delete(Product product)
		{
			_productDal.Delete(product);
			return new SuccessResult(Messages.ProductDeleted);
 		}

		public IDataResult<Product> GetById(int productId)
		{
			return new SuccessDataResult<Product>(_productDal.Get(x=>x.ProductId==productId));
		}
		[PerformanceAspect(5)]
		public IDataResult<List<Product>> GetList()
		{
			Thread.Sleep(5000);
			return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
		}
		[SecuredOperation("Product.List,Admin")] //Product.List veya Admin rolüne sahip olan kullanıcılar
		[CacheAspect(1)] //1 dakika 
		public IDataResult<List<Product>> GetListByCategory(int categoryId)
		{
			return new SuccessDataResult<List<Product>>(_productDal.GetList(x => x.CategoryId == categoryId).ToList());
		}
		[TransactionScopeAspect]
		public IResult TransactionalOperation(Product product)
		{
			_productDal.Update(product);
			_productDal.Add(product);
			return new SuccessResult(Messages.ProductUpdated);
		}

		public IResult Update(Product product)
		{
			_productDal.Update(product);
			return new SuccessResult(Messages.ProductUpdated);
		}
	}
}
