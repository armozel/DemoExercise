using DemoExercise.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DemoExercise.Context
{
    public class DemoContext : DbContext
    {
        public DemoContext() { }

        public DemoContext(DbContextOptions<DemoContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserLoginHistory> UserLoginHistories { get; set; }
    }
}
