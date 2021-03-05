using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.Security.Jwt
{

    public class JwtHelper : ITokenHelper
    {
        //Apiden gelen verileri okuyabilmek için Configuration işlemi yapıyoruz. using Microsoft.Extensions.Configuration; destekliyor

        public IConfiguration Configuration { get; } //Apiden gelen apsetting dosyalarını okumamızı sağlıyor.
        private TokenOptions _tokenOptions; //Apiden gelen apsetting dosyasının elemanlarını çağıramızı sağlıyor.
        private DateTime _accessTokenExpiration; //Token ne zaman sonlanacak bilgisini çağırmamızı sağlıyor.
        public JwtHelper(IConfiguration configuration) //Buraya injection yaptın
        {
            //AppSettings deki token options bölümünü al. TokenOptions sınıfının değerlerini elemanlarını alarak eşleştir (ata)
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, 
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,
                claims: SetClaims(user,operationClaims),
                signingCredentials:signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.UserId.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}"); // $ işareti iki tane stringi yan yana yazabilmemize olanak sağlıyor.
            claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray());
            
            return claims;
        }
    }
}
