using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Publications.Web.Data.Migrations
{
    public partial class Publications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08d46b21-bf8f-4132-bc73-f36beb0c2e0c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "40d14a4f-5166-4929-8eff-42a1d2dd2d14", "b40d9b8f-8fe4-4bc9-a5ac-dd7f85d5d642" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b40d9b8f-8fe4-4bc9-a5ac-dd7f85d5d642");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40d14a4f-5166-4929-8eff-42a1d2dd2d14");

            migrationBuilder.AddColumn<int>(
                name: "PublicationId",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TypeId = table.Column<int>(nullable: true),
                    PlaceId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_PublicationPlaces_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "PublicationPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publications_PublicationTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "PublicationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8263bd4-d82c-4a73-a501-16c19550d5a0", "ce721beb-2131-4499-9c9e-a7bdc406c040", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a52f144-5e6b-48f2-812b-415f66385856", "e05d69f1-6ec6-4268-b3ab-667dee9c4e00", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b6a94945-d30e-447e-bc73-e4c85afd8b25", 0, "b38a308c-66f6-46c5-a68c-fd2bb53bc797", null, false, false, null, null, null, "AQAAAAEAACcQAAAAEFY6yFdH4BLjOx9vM+yUVNpXwwBDKZ4Oh7a/XZ55perB8uoE1d5miikQl1vsEmvUwg==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b6a94945-d30e-447e-bc73-e4c85afd8b25", "f8263bd4-d82c-4a73-a501-16c19550d5a0" });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PublicationId",
                table: "Authors",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PlaceId",
                table: "Publications",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_TypeId",
                table: "Publications",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Publications_PublicationId",
                table: "Authors",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Publications_PublicationId",
                table: "Authors");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Authors_PublicationId",
                table: "Authors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a52f144-5e6b-48f2-812b-415f66385856");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b6a94945-d30e-447e-bc73-e4c85afd8b25", "f8263bd4-d82c-4a73-a501-16c19550d5a0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8263bd4-d82c-4a73-a501-16c19550d5a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6a94945-d30e-447e-bc73-e4c85afd8b25");

            migrationBuilder.DropColumn(
                name: "PublicationId",
                table: "Authors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b40d9b8f-8fe4-4bc9-a5ac-dd7f85d5d642", "70361186-b338-444f-9064-f1313a6cdf15", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08d46b21-bf8f-4132-bc73-f36beb0c2e0c", "32913118-6dc7-485e-8feb-6c975ea07abe", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "40d14a4f-5166-4929-8eff-42a1d2dd2d14", 0, "5f2f4be7-013c-4d34-8d57-cb77ff1edc05", null, false, false, null, null, null, "AQAAAAEAACcQAAAAEEZ5zLD+0+YQZbjr73qU+7ckpQ0hJBMDWX3EotyGAUsNmR/fa66bVWUkP/1WegmCEw==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "40d14a4f-5166-4929-8eff-42a1d2dd2d14", "b40d9b8f-8fe4-4bc9-a5ac-dd7f85d5d642" });
        }
    }
}
