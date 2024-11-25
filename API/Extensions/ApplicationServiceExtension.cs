﻿using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection addApplicationServices(this IServiceCollection services,
    IConfiguration config){

    services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddDbContext<DataContext>(opt=>{
    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
});
services.AddCors();
services.AddScoped<ITokenService,TokenService>();

return services;
    }

}