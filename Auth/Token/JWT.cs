using blogBlazor.Components.DB;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace blogBlazor.Components.Auth.Token
{
    public class JWT
    {
        
        public string GenerateJSONWebToken(userModel userInfo)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfsdafjdaslkfadshasdfkjhasdflkasfdjasdfl="));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string Revalidatetoken(string token)
        {
            return token;
        }
    }
}
