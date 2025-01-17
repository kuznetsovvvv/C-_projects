﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPIModels.Models;

namespace SQLServerWebApiConsoleClient.Models;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Shipper> Shippers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.Property(e => e.ShipperId).HasColumnName("ShipperID");
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(24);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}