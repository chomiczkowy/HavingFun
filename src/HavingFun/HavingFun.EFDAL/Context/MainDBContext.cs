using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace HavingFun.EFDA.Context
{
    public class MainDBContext : IdentityDbContext
    {
        public MainDBContext():base(new DbContextOptionsBuilder<MainDBContext>().UseNpgsql("Server = 127.0.0.1; Port = 5432; Database = HavingFun; User Id = postgres; Password = password").Options)
        {

        }

        public MainDBContext(DbContextOptions<MainDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
