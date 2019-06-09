﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesMovie.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(maxLength: 360, nullable: false),
                    AssignedTechnicians = table.Column<string>(nullable: true),
                    PostulatedTechnicians = table.Column<string>(nullable: true),
                    RequiredSpecialization = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Technician",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technician", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    TechnicianID = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false),
                    ProjectID1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => new { x.TechnicianID, x.ProjectID });
                    table.UniqueConstraint("AK_Assignment_ProjectID_TechnicianID", x => new { x.ProjectID, x.TechnicianID });
                    table.ForeignKey(
                        name: "FK_Assignment_Project_ProjectID1",
                        column: x => x.ProjectID1,
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Technician_TechnicianID",
                        column: x => x.TechnicianID,
                        principalTable: "Technician",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_ProjectID1",
                table: "Assignment",
                column: "ProjectID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Technician");
        }
    }
}
