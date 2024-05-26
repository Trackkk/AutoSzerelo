﻿// <auto-generated />
using System;
using AutoSzerelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoSzerelo.Migrations
{
    [DbContext(typeof(AutoSzereloKontextus))]
    partial class AutoSzereloKontextusModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("AutoSzereloShared.Kliens", b =>
                {
                    b.Property<Guid>("KliensId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("KliensNev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lakcim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("KliensId");

                    b.ToTable("Kliensek");
                });

            modelBuilder.Entity("AutoSzereloShared.Munka", b =>
                {
                    b.Property<Guid>("MunkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Allapot")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("GyartasiEv")
                        .HasColumnType("TEXT");

                    b.Property<int>("HibaSulyossaga")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("KliensId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Leiras")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("MKategoria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rendszam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MunkaId");

                    b.ToTable("Munkak");
                });
#pragma warning restore 612, 618
        }
    }
}
