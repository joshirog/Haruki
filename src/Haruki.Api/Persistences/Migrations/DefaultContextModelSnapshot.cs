﻿// <auto-generated />
using System;
using Haruki.Api.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Haruki.Api.Persistences.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Haruki.Api.Domains.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid")
                        .HasColumnOrder(0)
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(18);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("created_by")
                        .HasColumnOrder(19);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name")
                        .HasColumnOrder(2);

                    b.Property<Guid>("ServiceId")
                        .HasMaxLength(36)
                        .HasColumnType("uuid")
                        .HasColumnName("service_id")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("updated_by")
                        .HasColumnOrder(21);

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("h1_service_categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("10000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Dogs",
                            ServiceId = new Guid("10000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("20000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Cats",
                            ServiceId = new Guid("10000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("30000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Birds",
                            ServiceId = new Guid("10000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("40000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Fishes",
                            ServiceId = new Guid("10000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid")
                        .HasColumnOrder(0)
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp")
                        .HasColumnOrder(4);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(5);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("created_by")
                        .HasColumnOrder(6);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name")
                        .HasColumnOrder(1);

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name")
                        .HasColumnOrder(2);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(7);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("updated_by")
                        .HasColumnOrder(8);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("h0_roles", (string)null);
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("h0_role_claims", (string)null);
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid")
                        .HasColumnOrder(0)
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(18);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("created_by")
                        .HasColumnOrder(19);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name")
                        .HasColumnOrder(1);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("updated_by")
                        .HasColumnOrder(21);

                    b.HasKey("Id");

                    b.ToTable("h1_services", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("10000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Adoption"
                        },
                        new
                        {
                            Id = new Guid("20000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Grooming"
                        },
                        new
                        {
                            Id = new Guid("30000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Veterinary"
                        },
                        new
                        {
                            Id = new Guid("40000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Medicine"
                        },
                        new
                        {
                            Id = new Guid("50000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Foods"
                        },
                        new
                        {
                            Id = new Guid("60000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Training"
                        },
                        new
                        {
                            Id = new Guid("70000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Boarding"
                        },
                        new
                        {
                            Id = new Guid("80000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Toys"
                        },
                        new
                        {
                            Id = new Guid("90000000-0000-0000-0000-000000000000"),
                            CreatedAt = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = "system@globokas.com",
                            Name = "Accessories"
                        });
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36)
                        .HasColumnType("uuid")
                        .HasColumnOrder(0)
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count")
                        .HasColumnOrder(15);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp")
                        .HasColumnOrder(9);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasColumnOrder(18);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("created_by")
                        .HasColumnOrder(19);

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email")
                        .HasColumnOrder(3);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed")
                        .HasColumnOrder(6);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled")
                        .HasColumnOrder(14);

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end")
                        .HasColumnOrder(13);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email")
                        .HasColumnOrder(4);

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_username")
                        .HasColumnOrder(2);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash")
                        .HasColumnOrder(7);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number")
                        .HasColumnOrder(10);

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed")
                        .HasColumnOrder(11);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("text")
                        .HasColumnName("refresh_token")
                        .HasColumnOrder(16);

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp")
                        .HasColumnOrder(8);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status")
                        .HasColumnOrder(5);

                    b.Property<DateTime?>("TokenExpires")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("token_expires")
                        .HasColumnOrder(17);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled")
                        .HasColumnOrder(12);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasColumnOrder(20);

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("updated_by")
                        .HasColumnOrder(21);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("username")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("h0_users", (string)null);
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("h0_user_claims", (string)null);
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("h0_user_logins", (string)null);
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("h0_user_roles", (string)null);
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("h0_user_tokens", (string)null);
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.Category", b =>
                {
                    b.HasOne("Haruki.Api.Domains.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.RoleClaim", b =>
                {
                    b.HasOne("Haruki.Api.Domains.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.UserClaim", b =>
                {
                    b.HasOne("Haruki.Api.Domains.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.UserLogin", b =>
                {
                    b.HasOne("Haruki.Api.Domains.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.UserRole", b =>
                {
                    b.HasOne("Haruki.Api.Domains.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Haruki.Api.Domains.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Haruki.Api.Domains.Entities.UserToken", b =>
                {
                    b.HasOne("Haruki.Api.Domains.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
