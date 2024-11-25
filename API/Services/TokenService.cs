using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using Microsoft.IdentityModel.Tokens;

namespace API;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        var Token = config["TokenKey"] ?? throw new Exception("no access token");
        if(Token.Length < 64) throw new Exception("not valid token");

        var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Token));

        var claims= new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier,user.UserName)
        };
  var creds= new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(claims),
            Expires=DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };


        var tokenHandler=new JwtSecurityTokenHandler();
        var tkon = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(tkon);
    }
}
