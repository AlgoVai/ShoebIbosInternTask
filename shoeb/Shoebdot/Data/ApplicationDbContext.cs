using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shoebdot.Models;
using System.Collections.Generic;

namespace Shoebdot.Data
{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the one-to-many relationship
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendances) // Employee has many EmployeeAttendance records
                .WithOne(ea => ea.EmployeeId)  // EmployeeAttendance belongs to one Employee
                .HasForeignKey(ea => ea.EmployeeId); // Define the foreign key property

            // Your other entity configurations...
        }*/
 


        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }

    }
}
