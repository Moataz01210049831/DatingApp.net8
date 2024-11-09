﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;



[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context):ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users=await context.Users.ToListAsync();
            return users;
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<AppUser>> getUser(int id){
        var user =await context.Users.FindAsync(id);
        if(user==null) return NotFound();
        return user;
    }

}
