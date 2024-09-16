using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Employee table configurations
            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired();

            // Many-to-Many relationship with Project
            builder.HasMany(e => e.Projects)
                .WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeProject",
                    ep => ep.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
                    ep => ep.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId"));
        }
    }
}
