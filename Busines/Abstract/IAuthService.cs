using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busines.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email); //Kullanıcının var olup olmadığını mail ile kontrol ediyoruz. Aynı meail varsa kullanıcı vardır.
        IDataResult<AccessToken> CreateAccessToken(User user); // Yeni gelen kullanıcı için token oluşturuluyor.
    }
}
