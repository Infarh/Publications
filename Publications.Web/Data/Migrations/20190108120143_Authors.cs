using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Publications.Web.Data.Migrations
{
    public partial class Authors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorDegrees",
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
                    table.PrimaryKey("PK_AuthorDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorGrades",
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
                    table.PrimaryKey("PK_AuthorGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPositions",
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
                    table.PrimaryKey("PK_AuthorPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    PositionId = table.Column<int>(nullable: true),
                    DegreeId = table.Column<int>(nullable: true),
                    GradeId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_AuthorDegrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "AuthorDegrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authors_AuthorGrades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "AuthorGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Authors_AuthorPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "AuthorPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Authors_DegreeId",
                table: "Authors",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_GradeId",
                table: "Authors",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PositionId",
                table: "Authors",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "AuthorDegrees");

            migrationBuilder.DropTable(
                name: "AuthorGrades");

            migrationBuilder.DropTable(
                name: "AuthorPositions");

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
        }
    }
}
