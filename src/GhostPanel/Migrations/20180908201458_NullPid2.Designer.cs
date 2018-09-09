﻿// <auto-generated />
using System;
using GameHostDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameHostDemo.Migrations
{
    [DbContext(typeof(GameHostDemoContext))]
    [Migration("20180908201458_NullPid2")]
    partial class NullPid2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("GameHostDemo.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DefaultPath");

                    b.Property<string>("ExeName");

                    b.Property<int>("MaxSlots");

                    b.Property<int>("MinSlots");

                    b.Property<string>("Name");

                    b.Property<int>("SteamAppId");

                    b.Property<string>("SteamUrl");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameHostDemo.Models.GameServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommandLine");

                    b.Property<int>("GameId");

                    b.Property<string>("HomeDirectory");

                    b.Property<string>("IpAddress");

                    b.Property<bool>("IsEnabled");

                    b.Property<int?>("LastPid");

                    b.Property<int>("Port");

                    b.Property<string>("ServerName");

                    b.Property<string>("StartPath");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameServers");
                });

            modelBuilder.Entity("GameHostDemo.Models.GameServer", b =>
                {
                    b.HasOne("GameHostDemo.Models.Game", "Game")
                        .WithMany("GameServers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
