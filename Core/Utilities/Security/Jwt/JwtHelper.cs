using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
	public class JwtHelper : ITokenHelper
	{
		public IConfiguration Configuration { get; }
		private TokenOptions _tokenOptions;
		private DateTime _accessTokenExpiration;
		public JwtHelper(IConfiguration configuration, TokenOptions tokenOptions, DateTime accessTokenExpiration)
		{
			Configuration = configuration;
			_tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
			_accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
		}

		public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
		{
			var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
			var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
			return default;
		}

		public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, 
			SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
		{
			var jwt = new JwtSecurityToken(
				issuer:tokenOptions.Issuer,
				audience:tokenOptions.Audience,
				expires: _accessTokenExpiration,
				notBefore:DateTime.Now,
				claims:operationClaims,
				signingCredentials:signingCredentials
				);
		}

		//claim olarak set edeceğim bir metot
		private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
		{
			var claims = new List<Claim>();
			claims.Add(new Claim("email",user.Email));
		}
	}
}
