using Ex3.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Ex3.Repositories
{
    public class TasksDbContext:DbContext
    {



        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
        {

        }

        public DbSet<Tasks> tasks { get; set; }
    }
}
