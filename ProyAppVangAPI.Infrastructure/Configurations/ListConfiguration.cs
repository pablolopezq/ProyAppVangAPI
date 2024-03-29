﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyAppVangAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyAppVangAPI.Infrastructure.Configurations
{
    public class ListConfiguration : IEntityTypeConfiguration<Lista>
    {
        public void Configure(EntityTypeBuilder<Lista> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();
        }
    }
}