using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CSharp_ApiWithMoq.Src.Services
{
    public static class Settings
    {
        public static string Secret = "sggduWHHSGutia";
    }
    public static class TokenService
    {

        public static string GenerateToken()
        {
            var token = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new JwtSecurityToken(
                   expires: DateTime.Now.AddMinutes(30),
                   signingCredentials:
                   new SigningCredentials(
                       new SymmetricSecurityKey(token),
                       SecurityAlgorithms.HmacSha256Signature)
             );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokn = tokenHandler.WriteToken(tokenDescriptor);
            return tokn;
        }
    }
}
