using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentTask.Migrations
{
    /// <inheritdoc />
    public partial class ggh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Gender = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Dateofbirth = table.Column<DateTime>(type: "date", nullable: false),
                    city = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Is_enrolled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__3214EC27A5EC8265", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
