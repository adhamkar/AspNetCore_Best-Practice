using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) :base(dbContextOptions)
        {
            
        }
        public DbSet<Products> Products {get;set;}
        public DbSet<Category> Categories{get;set;}
        public DbSet<Comments> Comments {get;set;}
    }
}