﻿// <auto-generated />
using FinGoals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinGoals.Migrations
{
    [DbContext(typeof(GoalContext))]
    partial class GoalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("FinGoals.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("Description");

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Goals");
                });
#pragma warning restore 612, 618
        }
    }
}
