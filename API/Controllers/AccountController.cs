using System.Security.Cryptography;
using System.Text;
using API;
using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


public class AccountController(DataContext context,ITokenService tokenService): BaseApiController
{
  [HttpPost("Register")]
  public async Task<ActionResult<UserDto>> Register(RegisteDTO registeDto){
if(await userExist(registeDto.Username)) return BadRequest("user is Exist");
    using var hmc=new HMACSHA512(); //DTO data transfer object
    var user=new AppUser{
        UserName=registeDto.Username.ToLower(),
        passwordsHash=hmc.ComputeHash(Encoding.UTF8.GetBytes(registeDto.Password)),
        passwordsSalt=hmc.Key
    };

    context.Users.Add(user);
    await context.SaveChangesAsync();
    // return user;
    return new UserDto{
      Username=user.UserName,
      Token=tokenService.CreateToken(user)
    };
  }

  private async Task<bool>userExist(string username){


    return await context.Users.AnyAsync(x => x.UserName.ToLower()==username.ToLower());
  }


  [HttpPost("login")]
  public async Task<ActionResult<UserDto>>Login( LoginDTO loginDto){
    var user = await context.Users.FirstOrDefaultAsync(x=>x.UserName.ToLower() == loginDto.username.ToLower());
    if(user==null) return Unauthorized("invalid name");
    using var hmc =new HMACSHA3_512(user.passwordsSalt);
    var compulytedHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(loginDto.password));

    for (int i = 0; i < compulytedHash.Length; i++)
    {
      if(compulytedHash[i]!=user.passwordsHash[i]){
        return Unauthorized("invalid password");
      }

     
      
    }
    // return user;
    return new UserDto{
      Username=user.UserName,
      Token=tokenService.CreateToken(user)
    };
  }
}
