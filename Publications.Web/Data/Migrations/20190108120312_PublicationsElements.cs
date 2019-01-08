using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Publications.Web.Data.Migrations
{
    public partial class PublicationsElements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "094ff32c-347d-4947-8eba-e1f7aea38ff9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "fa52de6b-cb50-4439-a70f-402de5edf037", "c05a8f20-f990-48ee-be10-fc56e0ae0dac" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c05a8f20-f990-48ee-be10-fc56e0ae0dac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa52de6b-cb50-4439-a70f-402de5edf037");

            migrationBuilder.CreateTable(
                name: "PublicationPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublicationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationTypes", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationPlaces");

            migrationBuilder.DropTable(
                name: "PublicationTypes");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c05a8f20-f990-48ee-be10-fc56e0ae0dac", "52db72ff-0eee-47c3-b04b-bbde4c007049", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "094ff32c-347d-4947-8eba-e1f7aea38ff9", "05ca32e6-cbf0-4adf-894d-1f9f27c9d64d", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa52de6b-cb50-4439-a70f-402de5edf037", 0, "eeaadb33-f1f9-4d07-beaa-521533e98389", null, false, false, null, null, null, "AQAAAAEAACcQAAAAELcbIscFDA3yN0AEiv/jncMrL/6GdWMvFpAjuJX1TZBSPH8Wj/UGyCwiNn9bqiBaLQ==", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "fa52de6b-cb50-4439-a70f-402de5edf037", "c05a8f20-f990-48ee-be10-fc56e0ae0dac" });
        }
    }
}
