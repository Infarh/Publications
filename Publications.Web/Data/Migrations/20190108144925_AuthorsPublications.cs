using Microsoft.EntityFrameworkCore.Migrations;

namespace Publications.Web.Data.Migrations
{
    public partial class AuthorsPublications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Publications_PublicationId",
                table: "Authors");

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

            migrationBuilder.CreateTable(
                name: "AuthorPublication",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false),
                    PublicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPublication", x => new { x.AuthorId, x.PublicationId });
                    table.ForeignKey(
                        name: "FK_AuthorPublication_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPublication_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34ac5649-c3de-4bfe-82c8-356fd910fd75", "a5e85ac7-e581-49da-b6f3-9b0fe04dda8b", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a9c986f-a9d2-43fa-ab39-aac257f9aa24", "0a5d5dd8-0498-4594-8709-6962f53352be", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66f31857-d511-47ed-813f-2ccfbf2a356c", 0, "c9585ae8-34f0-4817-bd71-2f08e48f554a", null, false, false, null, null, null, "AQAAAAEAACcQAAAAELZGRAStWw2Egiwcov6kM5LNVYXNiEgLIH6B9hva7NCuJmtq7MJFfxqQeLufg2gbsA==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "66f31857-d511-47ed-813f-2ccfbf2a356c", "34ac5649-c3de-4bfe-82c8-356fd910fd75" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPublication_PublicationId",
                table: "AuthorPublication",
                column: "PublicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPublication");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a9c986f-a9d2-43fa-ab39-aac257f9aa24");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "66f31857-d511-47ed-813f-2ccfbf2a356c", "34ac5649-c3de-4bfe-82c8-356fd910fd75" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34ac5649-c3de-4bfe-82c8-356fd910fd75");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66f31857-d511-47ed-813f-2ccfbf2a356c");

            migrationBuilder.AddColumn<int>(
                name: "PublicationId",
                table: "Authors",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Publications_PublicationId",
                table: "Authors",
                column: "PublicationId",
                principalTable: "Publications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
