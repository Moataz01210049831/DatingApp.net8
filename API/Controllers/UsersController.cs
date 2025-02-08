using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


 [Authorize]
public class UsersController(IUserRepository userRepository,IMapper mapper):BaseApiController
{
    [HttpGet]
   
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers(){
            var users=await userRepository.GetUsersAsync();
            var usersToReturn =mapper.Map<IEnumerable<MemberDto>>(users); 
            return Ok(usersToReturn);
    }

    // [HttpGet("{id}")]

    // public async Task<ActionResult<AppUser>> getUser(int id){
    //     var user =await userRepository.GetUserByIdAsync(id);
    //     if(user==null) return NotFound();
    //     return user;
    // }
[HttpGet("{username}")]
     public async Task<ActionResult<MemberDto>> getUser(string username){
        var user =await userRepository.GetUserByUserNameAsync(username);
        if(user==null) return NotFound();
        return mapper.Map<MemberDto>(user);
    }

}
