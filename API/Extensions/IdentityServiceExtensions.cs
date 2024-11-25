﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityServiceExtensions
{
     public static IServiceCollection addIdentityService(this IServiceCollection services,
    IConfiguration config){
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options=>{
var TokenKey=config["TokenKey"] ?? throw new Exception("token key not found");
options.TokenValidationParameters=new TokenValidationParameters{
    ValidateIssuerSigningKey=true,
    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey)),
ValidateIssuer=false,
ValidateAudience=false
};
});
return services;
    }
}