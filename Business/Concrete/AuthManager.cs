﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class AuthManager : IAuthService
	{
		private IUserService _userService;
		private ITokenHelper _tokenHelper;
		public AuthManager(IUserService userService, ITokenHelper tokenHelper)
		{
			_userService = userService;
			_tokenHelper = tokenHelper;
		}

		public IDataResult<AccessToken> CreateAccessToken(User user)
		{
			throw new NotImplementedException();
		}

		public IDataResult<User> Login(UserForLoginDto userForLoginDto)
		{
			//once kullanıcıyı veritabanından cekelim
			var userToCheck = _userService.GetByMail(userForLoginDto.Email);
			if (userToCheck == null)
			{
				return new ErrorDataResult<User>(Messages.UserNotFound);
			}
			if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash,
														userToCheck.PasswordSalt))
			{
				//passwor 'lar eşleşmiyor ise
				return new ErrorDataResult<User>(Messages.PasswordError);
			}

			//artık kullanıcıyı login edebilirim
			return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
		}

		public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
		{
			throw new NotImplementedException();
		}

		public IResult UserExist(string email)
		{
			if(_userService.GetByMail(email) != null)
			{
				return new ErrorResult(Messages.UserAldreadyExist);
			}
			return new SuccessResult();
		}
	}
}
