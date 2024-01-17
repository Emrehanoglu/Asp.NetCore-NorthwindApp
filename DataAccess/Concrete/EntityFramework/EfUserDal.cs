using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
	{
		public List<OperationClaim> GetClaims(User user)
		{
			using (var context = new NorthwindContext())
			{
				var result = from userOperationClaim in context.UserOperationClaims
							 join operationClaim in context.OperationClaims
							 on userOperationClaim.OperationClaimId equals operationClaim.Id
							 where userOperationClaim.UserId == user.Id
							 select new OperationClaim
							 {
								 Id = operationClaim.Id,
								 Name = operationClaim.Name
							 };
				return result.ToList();
			}
		}
	}
}
