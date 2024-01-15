using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
	public class JwtHelper : ITokenHelper
	{
		public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
		{
			throw new NotImplementedException();
		}
	}
}
