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

            modelBuilder.Entity("GhostPanel.Core.Data.Model.CustomVariable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameServerId");

                    b.Property<string>("VariableName");

                    b.Property<string>("VariableValue");

                    b.HasKey("Id");

                    b.HasIndex("GameServerId");

                    b.ToTable("CustomVariable");
                });

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

                    b.Property<int>("GameProtocolId");

                    b.Property<int>("MaxSlots");

                    b.Property<int>("MinSlots");

                    b.Property<string>("Name");

                    b.Property<int>("PortIncrement");

                    b.Property<int>("QueryPort");

                    b.Property<int?>("SteamAppId");

                    b.Property<string>("SteamUrl");

                    b.HasKey("Id");

                    b.HasIndex("GameProtocolId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameDefaultConfigFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("FilePath");

                    b.Property<int>("GameId");

                    b.Property<string>("Template");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameDefaultConfigFile");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameProtocol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullTypeName");

                    b.Property<string>("Name");

                    b.Property<string>("ServerInfoType");

                    b.HasKey("Id");

                    b.ToTable("GameProtocol");
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

                    b.Property<Guid>("Guid");

                    b.Property<string>("HomeDirectory");

                    b.Property<string>("IpAddress");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("QueryPort");

                    b.Property<string>("RconPassword");

                    b.Property<string>("ServerName");

                    b.Property<int>("Slots");

                    b.Property<string>("StartDirectory");

                    b.Property<int?>("UserId");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameServers");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameServerConfigFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("FileContent");

                    b.Property<string>("FilePath");

                    b.Property<int?>("GameDefaultConfigFileId");

                    b.Property<int?>("GameServerId");

                    b.HasKey("Id");

                    b.HasIndex("GameDefaultConfigFileId");

                    b.HasIndex("GameServerId");

                    b.ToTable("GameServerConfigFile");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameServerCurrentStats", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CurrentPlayers");

                    b.Property<string>("Map");

                    b.Property<int>("MaxPlayers");

                    b.Property<string>("Name");

                    b.Property<int?>("Pid");

                    b.Property<int>("RestartAttempts");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("GameServerCurrentStats");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<int>("GameServerId");

                    b.Property<string>("LastName");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.CustomVariable", b =>
                {
                    b.HasOne("GhostPanel.Core.Data.Model.GameServer", "GameServer")
                        .WithMany("CustomVariables")
                        .HasForeignKey("GameServerId");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.Game", b =>
                {
                    b.HasOne("GhostPanel.Core.Data.Model.GameProtocol", "GameProtocol")
                        .WithMany("Games")
                        .HasForeignKey("GameProtocolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameDefaultConfigFile", b =>
                {
                    b.HasOne("GhostPanel.Core.Data.Model.Game", "Game")
                        .WithMany("GameDefaultConfigFiles")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameServer", b =>
                {
                    b.HasOne("GhostPanel.Core.Data.Model.Game", "Game")
                        .WithMany("GameServers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GhostPanel.Core.Data.Model.User", "User")
                        .WithMany("GameServers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameServerConfigFile", b =>
                {
                    b.HasOne("GhostPanel.Core.Data.Model.GameDefaultConfigFile", "GameDefaultConfigFile")
                        .WithMany()
                        .HasForeignKey("GameDefaultConfigFileId");

                    b.HasOne("GhostPanel.Core.Data.Model.GameServer", "GameServer")
                        .WithMany("GameConfigFiles")
                        .HasForeignKey("GameServerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GhostPanel.Core.Data.Model.GameServerCurrentStats", b =>
                {
                    b.HasOne("GhostPanel.Core.Data.Model.GameServer", "GameServer")
                        .WithOne("GameServerCurrentStats")
                        .HasForeignKey("GhostPanel.Core.Data.Model.GameServerCurrentStats", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
