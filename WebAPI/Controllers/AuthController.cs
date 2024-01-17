using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}
		[HttpPost("login")]
		public IActionResult Login(UserForLoginDto userForLoginDto)
		{
			var userToLogin = _authService.Login(userForLoginDto);
			if (!userToLogin.Success)
			{
				return BadRequest(userToLogin.Message);
			}
			//kullanıcı bu noktada login oldu, accesstoken üretmem gerekiyor
			var result = _authService.CreateAccessToken(userToLogin.Data);
			if (result.Success)
			{
				return Ok();
			}
			return BadRequest(result.Message);
		}
		[HttpPost("register")]
		public IActionResult Register(UserForRegisterDto userForRegisterDto)
		{
			//mevcutta boyle bir user var mı?
			var userExist = _authService.UserExist(userForRegisterDto.Email);
			if (!userExist.Success)
			{
				return BadRequest(userExist.Message);
			}
			//register işlemini yapalım
			var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

			//register işlemini yaptım, token üretelim
			var result = _authService.CreateAccessToken(registerResult.Data);

			//token üretme işlemi de ok ise
			if (result.Success)
			{
				return Ok(result.Data);
			}
			return BadRequest(result.Message);
		}
	}
}