﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.MiddleName)
               .HasMaxLength(50);

            builder.Property(e => e.LastName)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(e => e.MiddleLastName)
               .HasMaxLength(50);
        }
    }
}
