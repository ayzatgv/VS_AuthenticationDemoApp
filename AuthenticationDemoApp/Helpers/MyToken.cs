using AuthenticationDemoApp.DataAccess;
using AuthenticationDemoApp.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AuthenticationDemoApp.Helpers
{
    public static class MyToken
    {
        private static readonly string _secretkey = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string TokenGeneration(Models.User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Username));

            var token = tokenHandler.CreateJwtSecurityToken(expires: DateTime.UtcNow.AddHours(24), subject: claimsIdentity, signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.Default.GetBytes(_secretkey)), SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretkey)),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.FromMilliseconds(100)
            };
        }

        public static ClaimsPrincipal TokenDecryption(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();
            SecurityToken validatedToken;

            ClaimsPrincipal claimsPrincipal;

            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return null;
            }

            return claimsPrincipal;
        }

        public static bool TokenValidation(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            ClaimsPrincipal claimsPrincipal;

            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                Models.User user = UserService.Users_Select(Convert.ToInt32(claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value))[0];
                if (user.Token != token)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static int GetUserID(string token)
        {
            ClaimsPrincipal claimsPrincipal = TokenDecryption(token);

            return Convert.ToInt32(claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}