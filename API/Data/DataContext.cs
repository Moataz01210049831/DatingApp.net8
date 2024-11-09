﻿using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)  //to give it options we need to create constructor
{
    public DbSet<AppUser> Users {get; set;}
}
