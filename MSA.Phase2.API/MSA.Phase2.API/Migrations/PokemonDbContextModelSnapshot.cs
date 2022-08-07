﻿// <auto-generated />
using MSA.Phase2.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MSA.Phase2.API.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    partial class PokemonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MSA.Phase2.API.Data.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CodexNumber")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("Pokemons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodexNumber = 25,
                            Height = 4,
                            Name = "pikachu",
                            TrainerId = 1,
                            Weight = 60
                        },
                        new
                        {
                            Id = 2,
                            CodexNumber = 205,
                            Height = 12,
                            Name = "forretress",
                            TrainerId = 2,
                            Weight = 1258
                        },
                        new
                        {
                            Id = 3,
                            CodexNumber = 255,
                            Height = 4,
                            Name = "torchic",
                            TrainerId = 3,
                            Weight = 25
                        });
                });

            modelBuilder.Entity("MSA.Phase2.API.Data.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trainers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ash"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Brock"
                        },
                        new
                        {
                            Id = 3,
                            Name = "May"
                        });
                });

            modelBuilder.Entity("MSA.Phase2.API.Data.Pokemon", b =>
                {
                    b.HasOne("MSA.Phase2.API.Data.Trainer", "Trainer")
                        .WithMany("Pokemon")
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("MSA.Phase2.API.Data.Trainer", b =>
                {
                    b.Navigation("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
