﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Tower.Data;

namespace Tower.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171103222746_ProjectInitial")]
    partial class ProjectInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Tower.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Tower.Models.ClientViewModels.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<int?>("ContactId");

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Tower.Models.ClientViewModels.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientID");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("ClientID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Tower.Models.HomeViewModels.ContactModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ContactModel");
                });

            modelBuilder.Entity("Tower.Models.InventoryViewModels.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Tower.Models.LocationViewModels.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apartment");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Tower.Models.ProjectViewModels.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<float>("PercentComplete");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Tower.Models.ProjectViewModels.ProjectTask", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignedTeamId");

                    b.Property<float>("CompletionPercentage");

                    b.Property<int>("Complexity");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("InWork");

                    b.Property<string>("Priority");

                    b.Property<int?>("ProjectId");

                    b.Property<int?>("ProjectTaskID");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status");

                    b.Property<int>("StoryPoints");

                    b.Property<int?>("TaskId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Type");

                    b.HasKey("ID");

                    b.HasIndex("AssignedTeamId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ProjectTaskID");

                    b.HasIndex("TaskId");

                    b.ToTable("ProjectTask");
                });

            modelBuilder.Entity("Tower.Models.ServiceOrderViewModels.CommentViewModels.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentorId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("ServiceOrderId");

                    b.HasKey("Id");

                    b.HasIndex("CommentorId");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Tower.Models.ServiceOrderViewModels.ServiceOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignedId");

                    b.Property<DateTime>("CloseDate");

                    b.Property<string>("ClosedUserId");

                    b.Property<int?>("ContactId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<DateTime>("DueDate");

                    b.Property<bool>("IsClosed");

                    b.Property<string>("OpenUserId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<float>("TotalCharge");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AssignedId");

                    b.HasIndex("ClosedUserId");

                    b.HasIndex("ContactId");

                    b.HasIndex("OpenUserId");

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("Tower.Models.TeamViewModels.Team", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Tower.Models.TeamViewModels.TeamUser", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("TeamId");

                    b.HasKey("UserId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamUsers");
                });

            modelBuilder.Entity("Tower.Models.TrackerViewModels.TimeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("LoggedMinutes");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("UserId");

                    b.ToTable("TimeLog");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Tower.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Tower.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tower.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Tower.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tower.Models.ClientViewModels.Client", b =>
                {
                    b.HasOne("Tower.Models.LocationViewModels.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Tower.Models.ClientViewModels.Contact", "MainContact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("Tower.Models.ClientViewModels.Contact", b =>
                {
                    b.HasOne("Tower.Models.ClientViewModels.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");
                });

            modelBuilder.Entity("Tower.Models.ProjectViewModels.ProjectTask", b =>
                {
                    b.HasOne("Tower.Models.TeamViewModels.Team", "AssignedTeam")
                        .WithMany()
                        .HasForeignKey("AssignedTeamId");

                    b.HasOne("Tower.Models.ProjectViewModels.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("Tower.Models.ProjectViewModels.ProjectTask")
                        .WithMany("Dependencies")
                        .HasForeignKey("ProjectTaskID");

                    b.HasOne("Tower.Models.ProjectViewModels.Project")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("Tower.Models.ServiceOrderViewModels.CommentViewModels.Comment", b =>
                {
                    b.HasOne("Tower.Models.ApplicationUser", "Commentor")
                        .WithMany()
                        .HasForeignKey("CommentorId");

                    b.HasOne("Tower.Models.ServiceOrderViewModels.ServiceOrder", "ServiceOrder")
                        .WithMany()
                        .HasForeignKey("ServiceOrderId");
                });

            modelBuilder.Entity("Tower.Models.ServiceOrderViewModels.ServiceOrder", b =>
                {
                    b.HasOne("Tower.Models.ApplicationUser", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedId");

                    b.HasOne("Tower.Models.ApplicationUser", "ClosedBy")
                        .WithMany()
                        .HasForeignKey("ClosedUserId");

                    b.HasOne("Tower.Models.ClientViewModels.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("Tower.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("OpenUserId");
                });

            modelBuilder.Entity("Tower.Models.TeamViewModels.TeamUser", b =>
                {
                    b.HasOne("Tower.Models.TeamViewModels.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tower.Models.ApplicationUser", "User")
                        .WithMany("teams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tower.Models.TrackerViewModels.TimeLog", b =>
                {
                    b.HasOne("Tower.Models.ClientViewModels.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Tower.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
