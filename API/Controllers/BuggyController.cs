using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController(DataContext context):BaseApiController
{
[HttpGet("auth")]
public ActionResult<string> GetAuth(){
            return "secret Text";
}


[HttpGet("not-found")]
public ActionResult<AppUser> GetNotFound(){
    var thing = context.Users.Find(-1);
    if(thing== null) return NotFound();
            return thing;
}


[HttpGet("server-error")]
public ActionResult<AppUser> GetServerError(){
        var thing = context.Users.Find(-1)?? throw new Exception("something bad has happend");

        return thing;
}


[HttpGet("bad-request")]
public ActionResult<string> GetBadRequest(){
            return BadRequest("secret Text not right rquest");
}


}
