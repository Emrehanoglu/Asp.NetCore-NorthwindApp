using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
	public class TokenOptions
	{
		public string Audience { get; set; } //token 'ın kullanıcı kitlesi
		public string Issuer { get; set; } //token 'ı imzalayan
		public int AccessTokenExpiration { get; set; } //dk cinsinden token'ın gecerlilik süresi
		public string SecurityKey { get; set; }
	}
}
