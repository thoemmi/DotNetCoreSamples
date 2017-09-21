using Microsoft.EntityFrameworkCore;
using SelfHosted.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfHosted.DataAccess.SqlDataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
