﻿
using Microsoft.EntityFrameworkCore;

namespace VnsTrips.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Market> Markets { get; set; }
    }
}
