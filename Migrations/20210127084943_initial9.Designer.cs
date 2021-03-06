﻿// <auto-generated />
using IITS_Programming_Club.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IITS_Programming_Club.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210127084943_initial9")]
    partial class initial9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IITS_Programming_Club.Models.Admin", b =>
                {
                    b.Property<string>("admin_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("active_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("admin_phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_id");

                    b.ToTable("admin_info");
                });

            modelBuilder.Entity("IITS_Programming_Club.Models.ClassSchedule", b =>
                {
                    b.Property<int>("key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("change_plan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDone")
                        .HasColumnType("bit");

                    b.Property<string>("remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("room_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("key");

                    b.ToTable("class_info");
                });

            modelBuilder.Entity("IITS_Programming_Club.Models.Complain", b =>
                {
                    b.Property<string>("student_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("student_id");

                    b.ToTable("complain_info");
                });

            modelBuilder.Entity("IITS_Programming_Club.Models.Event", b =>
                {
                    b.Property<string>("event_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("event_for")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("event_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("event_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("winner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("event_id");

                    b.ToTable("event_info");
                });

            modelBuilder.Entity("IITS_Programming_Club.Models.Home", b =>
                {
                    b.Property<int>("key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("change_plan_advance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("change_plan_begineer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("change_plan_intermediate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("class_advance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("class_beginner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("class_intermediate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codeforces_handle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_advance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_begineer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("date_intermediate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("room_advance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("room_begineer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("room_intermediate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("student_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("student_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("time_advance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("time_begineer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("time_intermediate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("key");

                    b.ToTable("Home");
                });

            modelBuilder.Entity("IITS_Programming_Club.Models.Notice", b =>
                {
                    b.Property<string>("notice_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("notice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("notice_id");

                    b.ToTable("notice");
                });

            modelBuilder.Entity("IITS_Programming_Club.Models.Programmer", b =>
                {
                    b.Property<int>("key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDone")
                        .HasColumnType("bit");

                    b.Property<string>("week")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("key");

                    b.ToTable("prog_of_week");
                });

            modelBuilder.Entity("IITS_Programming_Club.Models.StudentInfo", b =>
                {
                    b.Property<string>("student_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("active_status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("atcoder_handle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("block_reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codechef_handle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codeforces_handle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("hackerrank_handle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("student_division")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("student_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("student_pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("student_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vjudge_handle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("student_id");

                    b.ToTable("student_info");
                });

            modelBuilder.Entity("IITS_Programming_Club.Models.ToDoList", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("isdone")
                        .HasColumnType("bit");

                    b.Property<string>("problem_link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("student_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("todolist");
                });
#pragma warning restore 612, 618
        }
    }
}
