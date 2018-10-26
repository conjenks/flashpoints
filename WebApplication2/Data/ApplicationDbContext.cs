using System;
using System.Collections.Generic;
using System.Text;
using FlashPoints.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlashPoints.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Prize> Prize { get; set; }
    }
}
