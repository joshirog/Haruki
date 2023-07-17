using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Haruki.Api.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialScheme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "h0_roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 36, nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h0_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "h0_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 36, nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    normalized_username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false),
                    refresh_token = table.Column<string>(type: "text", nullable: true),
                    token_expires = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h0_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "h1_services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 36, nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h1_services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "h0_role_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h0_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "FK_h0_role_claims_h0_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "h0_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "h0_user_claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h0_user_claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_h0_user_claims_h0_users_user_id",
                        column: x => x.user_id,
                        principalTable: "h0_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "h0_user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h0_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_h0_user_logins_h0_users_user_id",
                        column: x => x.user_id,
                        principalTable: "h0_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "h0_user_roles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h0_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_h0_user_roles_h0_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "h0_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_h0_user_roles_h0_users_user_id",
                        column: x => x.user_id,
                        principalTable: "h0_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "h0_user_tokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h0_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_h0_user_tokens_h0_users_user_id",
                        column: x => x.user_id,
                        principalTable: "h0_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "h1_service_categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 36, nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    service_id = table.Column<Guid>(type: "uuid", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    updated_by = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h1_service_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_h1_service_categories_h1_services_service_id",
                        column: x => x.service_id,
                        principalTable: "h1_services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "h1_services",
                columns: new[] { "Id", "created_at", "created_by", "name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Adoption", null, null },
                    { new Guid("20000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Grooming", null, null },
                    { new Guid("30000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Veterinary", null, null },
                    { new Guid("40000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Medicine", null, null },
                    { new Guid("50000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Foods", null, null },
                    { new Guid("60000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Training", null, null },
                    { new Guid("70000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Boarding", null, null },
                    { new Guid("80000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Toys", null, null },
                    { new Guid("90000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Accessories", null, null }
                });

            migrationBuilder.InsertData(
                table: "h1_service_categories",
                columns: new[] { "Id", "created_at", "created_by", "name", "service_id", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Dogs", new Guid("10000000-0000-0000-0000-000000000000"), null, null },
                    { new Guid("20000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Cats", new Guid("10000000-0000-0000-0000-000000000000"), null, null },
                    { new Guid("30000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Birds", new Guid("10000000-0000-0000-0000-000000000000"), null, null },
                    { new Guid("40000000-0000-0000-0000-000000000000"), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@globokas.com", "Fishes", new Guid("10000000-0000-0000-0000-000000000000"), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_h0_role_claims_role_id",
                table: "h0_role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "h0_roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_h0_user_claims_user_id",
                table: "h0_user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_h0_user_logins_user_id",
                table: "h0_user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_h0_user_roles_role_id",
                table: "h0_user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "h0_users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "h0_users",
                column: "normalized_username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_h1_service_categories_service_id",
                table: "h1_service_categories",
                column: "service_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "h0_role_claims");

            migrationBuilder.DropTable(
                name: "h0_user_claims");

            migrationBuilder.DropTable(
                name: "h0_user_logins");

            migrationBuilder.DropTable(
                name: "h0_user_roles");

            migrationBuilder.DropTable(
                name: "h0_user_tokens");

            migrationBuilder.DropTable(
                name: "h1_service_categories");

            migrationBuilder.DropTable(
                name: "h0_roles");

            migrationBuilder.DropTable(
                name: "h0_users");

            migrationBuilder.DropTable(
                name: "h1_services");
        }
    }
}
