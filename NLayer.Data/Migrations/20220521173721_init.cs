using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NLayer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFeatures");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "SchoolId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberOfStudents = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFeatures_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "CreatedDate", "Name", "NumberOfStudents", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 21, 20, 37, 20, 692, DateTimeKind.Local).AddTicks(4719), "MCBÜ", 35000, null },
                    { 2, new DateTime(2022, 5, 21, 20, 37, 20, 692, DateTimeKind.Local).AddTicks(4736), "MASKÜ", 35000, null },
                    { 3, new DateTime(2022, 5, 21, 20, 37, 20, 692, DateTimeKind.Local).AddTicks(4737), "EGE", 65000, null },
                    { 4, new DateTime(2022, 5, 21, 20, 37, 20, 692, DateTimeKind.Local).AddTicks(4738), "SAÜ", 45000, null }
                });

            migrationBuilder.InsertData(
                table: "StudentFeatures",
                columns: new[] { "Id", "Size", "StudentId", "Weight" },
                values: new object[,]
                {
                    { 1, 170.0, 1, 65.0 },
                    { 2, 165.0, 3, 60.0 },
                    { 3, 159.0, 2, 55.0 }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "SchoolId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "SchoolId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "SchoolId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedDate", "Name", "SchoolId", "Surname", "UpdatedDate" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İrem", 3, "YALIN", null });

            migrationBuilder.InsertData(
                table: "StudentFeatures",
                columns: new[] { "Id", "Size", "StudentId", "Weight" },
                values: new object[] { 4, 150.0, 4, 45.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFeatures_StudentId",
                table: "StudentFeatures",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Schools_SchoolId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "StudentFeatures");

            migrationBuilder.DropIndex(
                name: "IX_Students_SchoolId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFeatures_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedDate", "Grade", "Name", "StudentId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 20, 23, 24, 29, 101, DateTimeKind.Local).AddTicks(8618), 90, "Çevre Teknolojileri", 1, null },
                    { 2, new DateTime(2022, 5, 20, 23, 24, 29, 101, DateTimeKind.Local).AddTicks(8632), 100, "Yapay Zeka", 1, null },
                    { 3, new DateTime(2022, 5, 20, 23, 24, 29, 101, DateTimeKind.Local).AddTicks(8633), 85, "Enerji Verimliliği", 2, null },
                    { 4, new DateTime(2022, 5, 20, 23, 24, 29, 101, DateTimeKind.Local).AddTicks(8636), 100, "Serbest Kanat İHA", 3, null }
                });

            migrationBuilder.InsertData(
                table: "ProjectFeatures",
                columns: new[] { "Id", "Content", "LessonName", "ProjectId" },
                values: new object[,]
                {
                    { 1, "Daha yaşanılabilir bir dünya için insanları bilinçlendirme çalışması yapmak", "Coğrafya", 1 },
                    { 2, "Yapay zekayı tüm dünyaya yaymak için çalışmalar yapmak.", "Machine Learning", 2 },
                    { 3, "Enerji kaynaklarımızın kullanımına yönelik çalışmalar yapmak.", "Coğrafya", 3 },
                    { 4, "Kendi ihamızı kendimiz tasarlayalım konulu çalışma yapma.", "Elektrik", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFeatures_ProjectId",
                table: "ProjectFeatures",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StudentId",
                table: "Projects",
                column: "StudentId");
        }
    }
}
