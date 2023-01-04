using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;
namespace DAL.DataContext;

public partial class DbpracticaContext : DbContext
{
    public DbpracticaContext()
    {
    }

    public DbpracticaContext(DbContextOptions<DbpracticaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__EMPLEADO__CE6D8B9E79BCA03E");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.FechadeIngreso).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
