﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhasmophobiaDatabase.Data;

#nullable disable

namespace PhasmophobiaDatabase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230721064411_update2")]
    partial class update2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PhasmophobiaDatabase.Models.Evidence", b =>
                {
                    b.Property<int>("EvidenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvidenceId"));

                    b.Property<int>("GhostId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EvidenceId");

                    b.HasIndex("GhostId");

                    b.ToTable("Evidence");
                });

            modelBuilder.Entity("PhasmophobiaDatabase.Models.Ghost", b =>
                {
                    b.Property<int>("GhostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GhostId"));

                    b.Property<string>("Behaviour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JournalInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strengths")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Test")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weaknesses")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GhostId");

                    b.ToTable("Ghosts");
                });

            modelBuilder.Entity("PhasmophobiaDatabase.Models.SanityThreshold", b =>
                {
                    b.Property<int>("SanityThresholdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanityThresholdId"));

                    b.Property<int>("GhostId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SanityThresholdId");

                    b.HasIndex("GhostId");

                    b.ToTable("SanityThreshold");
                });

            modelBuilder.Entity("PhasmophobiaDatabase.Models.Speed", b =>
                {
                    b.Property<int>("SpeedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpeedId"));

                    b.Property<int>("GhostId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpeedId");

                    b.HasIndex("GhostId");

                    b.ToTable("Speed");
                });

            modelBuilder.Entity("PhasmophobiaDatabase.Models.Evidence", b =>
                {
                    b.HasOne("PhasmophobiaDatabase.Models.Ghost", "Ghost")
                        .WithMany("Evidence")
                        .HasForeignKey("GhostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ghost");
                });

            modelBuilder.Entity("PhasmophobiaDatabase.Models.SanityThreshold", b =>
                {
                    b.HasOne("PhasmophobiaDatabase.Models.Ghost", "Ghost")
                        .WithMany("SanityThreshold")
                        .HasForeignKey("GhostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ghost");
                });

            modelBuilder.Entity("PhasmophobiaDatabase.Models.Speed", b =>
                {
                    b.HasOne("PhasmophobiaDatabase.Models.Ghost", "Ghost")
                        .WithMany("Speed")
                        .HasForeignKey("GhostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ghost");
                });

            modelBuilder.Entity("PhasmophobiaDatabase.Models.Ghost", b =>
                {
                    b.Navigation("Evidence");

                    b.Navigation("SanityThreshold");

                    b.Navigation("Speed");
                });
#pragma warning restore 612, 618
        }
    }
}
