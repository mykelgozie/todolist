using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.data
{
    public class Appdbcontext : DbContext
    {

        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
        {

        }

        public DbSet<Tasks> Tasks  { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Cartegory> Cartegories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().HasData(

                new Tasks
                {

                    Id = 1,
                    Title = "Code",
                    Description = "open visual studio",
                    DueDate = DateTime.Now,
                    StatusId = 1,
                    CartegoryId = 1


                }


                );


            modelBuilder.Entity<Cartegory>().HasData(

                new Cartegory
                {
                    Id = 1,
                    Name = "Completed",
                }

                );





            modelBuilder.Entity<Status>().HasData(

                new Status
                {
                    Id = 1,
                    Name = "Completed",


                }

                );




        }
    }
}
