﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Data
{
    public class AuthenticationContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
