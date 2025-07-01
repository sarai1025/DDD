using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetsFoundation.Domain;

namespace PetsFoundation.Infraestructure.Persistance;

public partial class PetsContext : DbContext
{
    public PetsContext()
    {
    }

    public PetsContext(DbContextOptions<PetsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdoptionRequest> AdoptionRequests { get; set; }

    public virtual DbSet<Interested> Interesteds { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdoptionRequest>(entity =>
        {
            entity.HasKey(e => e.KAdoptionRequest).HasName("PK__Adoption__F5B827EB4C37596D");

            entity.Property(e => e.KAdoptionRequest)
                .ValueGeneratedNever()
                .HasColumnName("kAdoptionRequest");
            entity.Property(e => e.KInterested).HasColumnName("kInterested");
            entity.Property(e => e.KPet).HasColumnName("kPet");

            entity.HasOne(d => d.KInterestedNavigation).WithMany(p => p.AdoptionRequests)
                .HasForeignKey(d => d.KInterested)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdoptionR__kInte__4AB81AF0");

            entity.HasOne(d => d.KPetNavigation).WithMany(p => p.AdoptionRequests)
                .HasForeignKey(d => d.KPet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AdoptionRe__kPet__49C3F6B7");
        });

        modelBuilder.Entity<Interested>(entity =>
        {
            entity.HasKey(e => e.KInterested).HasName("PK__Interest__85479F705954CEA0");

            entity.ToTable("Interested");

            entity.Property(e => e.KInterested)
                .ValueGeneratedNever()
                .HasColumnName("kInterested");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IdentificationNumber).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.KPet).HasName("PK__Pets__DFC35C4A79DFE013");

            entity.Property(e => e.KPet)
                .ValueGeneratedNever()
                .HasColumnName("kPet");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.FirtName).HasMaxLength(50);
            entity.Property(e => e.KGodFather).HasColumnName("kGodFather");
            entity.Property(e => e.KOwner).HasColumnName("kOwner");
            entity.Property(e => e.Race).HasMaxLength(1);

            entity.HasOne(d => d.KGodFatherNavigation).WithMany(p => p.PetKGodFatherNavigations)
                .HasForeignKey(d => d.KGodFather)
                .HasConstraintName("FK__Pets__kGodFather__412EB0B6");

            entity.HasOne(d => d.KOwnerNavigation).WithMany(p => p.PetKOwnerNavigations)
                .HasForeignKey(d => d.KOwner)
                .HasConstraintName("FK__Pets__kOwner__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
