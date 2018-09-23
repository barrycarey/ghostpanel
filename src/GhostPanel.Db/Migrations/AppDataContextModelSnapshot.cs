﻿// <auto-generated />
using System;
using GhostPanel.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GhostPanel.Db.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GhostPanel.Core.Data.Model.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArchiveName");

                    b.Property<string>("DefaultPath");

                    b.Property<int>("DefaultSlots");

                    b.Property<string>("ExeName");

                    b.Property<int>("GamePort");

                    b.Property<int>("MaxSlots");

                    b.Property<int>("MinSlots");

                    b.Property<string>("Name");

                    b.Property<int>("PortIncrement");

                    b.Property<int>("QueryPort");

                    b.Property<int?>("SteamAppId");

                    b.Property<string>("SteamUrl");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommandLine");

                    b.Property<string>("CustomCommandLineArgs");

                    b.Property<int>("GameId");

                    b.Property<int>("GamePort");

                    b.Property<string>("HomeDirectory");

                    b.Property<string>("IpAddress");

                    b.Property<bool>("IsEnabled");

                    b.Property<int?>("Pid");

                    b.Property<int>("QueryPort");

                    b.Property<string>("RconPassword");

                    b.Property<int>("RestartAttempts");

                    b.Property<string>("ServerName");

                    b.Property<int>("Slots");

                    b.Property<string>("StartDirectory");

                    b.Property<int>("Status");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameServers");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameServer", b =>
                {
                    b.HasOne("GhostPanel.Core.Data.Model.Game", "Game")
                        .WithMany("GameServers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
