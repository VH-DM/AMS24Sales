﻿using System;
using AMS3A.Sales.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AMS3A.Sales.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20240409174450_EntitiesRelation")]
    partial class EntitiesRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("AMS3A.Sales.API.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActived")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AMS3A.Sales.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("AMS3A.Sales.Domain.Product", b =>
                {
                    b.HasOne("AMS3A.Sales.API.Domain.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AMS3A.Sales.API.Domain.Category", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
