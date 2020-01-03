﻿// <auto-generated />
using System;
using FoodApp.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodApp.Model.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Carbs");

                    b.Property<int>("Fat");

                    b.Property<string>("Image");

                    b.Property<int>("Kcal");

                    b.Property<int>("PrepTime");

                    b.Property<int>("Protein");

                    b.Property<string>("Title");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("FoodApp.Model.RecipeTag", b =>
                {
                    b.Property<Guid>("RecipeId");

                    b.Property<Guid>("TagId");

                    b.HasKey("RecipeId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("RecipeTag");
                });

            modelBuilder.Entity("FoodApp.Model.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("FoodApp.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodApp.Model.Recipe", b =>
                {
                    b.HasOne("FoodApp.Model.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FoodApp.Model.RecipeTag", b =>
                {
                    b.HasOne("FoodApp.Model.Recipe", "Recipe")
                        .WithMany("RecipeTags")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodApp.Model.Tag", "Tag")
                        .WithMany("RecipeTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
