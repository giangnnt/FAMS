﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FAMS.Migrations
{
    public partial class FAMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutputStandard",
                columns: table => new
                {
                    OutputStandardId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputStandard", x => x.OutputStandardId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Permissionid = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Permissionid);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    PermissionsPermissionid = table.Column<string>(type: "text", nullable: false),
                    RolesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => new { x.PermissionsPermissionid, x.RolesId });
                    table.ForeignKey(
                        name: "FK_PermissionRole_Permissions_PermissionsPermissionid",
                        column: x => x.PermissionsPermissionid,
                        principalTable: "Permissions",
                        principalColumn: "Permissionid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Syllabuses",
                columns: table => new
                {
                    SyllabusId = table.Column<Guid>(type: "uuid", nullable: false),
                    TopicCode = table.Column<string>(type: "text", nullable: false),
                    TopicName = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    TrainingAudience = table.Column<string>(type: "text", nullable: false),
                    TechnicalRequirement = table.Column<string>(type: "text", nullable: true),
                    CourseObjective = table.Column<string>(type: "text", nullable: true),
                    TimeLocation = table.Column<string>(type: "text", nullable: true),
                    DeliveryPrinciple = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabuses", x => x.SyllabusId);
                    table.ForeignKey(
                        name: "FK_Syllabuses_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPrograms",
                columns: table => new
                {
                    TrainingProgramCode = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPrograms", x => x.TrainingProgramCode);
                    table.ForeignKey(
                        name: "FK_TrainingPrograms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AsessmentScheme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quiz = table.Column<int>(type: "integer", nullable: true),
                    Assigment = table.Column<int>(type: "integer", nullable: true),
                    Final = table.Column<int>(type: "integer", nullable: true),
                    Finaltheory = table.Column<int>(type: "integer", nullable: true),
                    Finalpratical = table.Column<int>(type: "integer", nullable: true),
                    Gpa = table.Column<int>(type: "integer", nullable: true),
                    SyllabusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsessmentScheme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsessmentScheme_Syllabuses_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "Syllabuses",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingUnits",
                columns: table => new
                {
                    UnitCode = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitName = table.Column<string>(type: "text", nullable: true),
                    DayNumber = table.Column<int>(type: "integer", nullable: true),
                    Topiccode = table.Column<string>(type: "text", nullable: true),
                    SyllabusId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingUnits", x => x.UnitCode);
                    table.ForeignKey(
                        name: "FK_TrainingUnits_Syllabuses_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "Syllabuses",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingProgramcode = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassName = table.Column<string>(type: "text", nullable: false),
                    ClassCode = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    FSU = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TrainingProgramCode = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Class_TrainingPrograms_TrainingProgramCode",
                        column: x => x.TrainingProgramCode,
                        principalTable: "TrainingPrograms",
                        principalColumn: "TrainingProgramCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgramSyllabuses",
                columns: table => new
                {
                    TopicCode = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingProgramCode = table.Column<Guid>(type: "uuid", nullable: false),
                    Sequence = table.Column<string>(type: "text", nullable: true),
                    SyllabusId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingProgramCode1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgramSyllabuses", x => new { x.TopicCode, x.TrainingProgramCode });
                    table.ForeignKey(
                        name: "FK_TrainingProgramSyllabuses_Syllabuses_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "Syllabuses",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingProgramSyllabuses_TrainingPrograms_TrainingProgramC~",
                        column: x => x.TrainingProgramCode1,
                        principalTable: "TrainingPrograms",
                        principalColumn: "TrainingProgramCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingContents",
                columns: table => new
                {
                    TrainingContentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentName = table.Column<string>(type: "text", nullable: false),
                    Trainingtime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Method = table.Column<string>(type: "text", nullable: false),
                    DeliveryType = table.Column<string>(type: "text", nullable: true),
                    UnitCode = table.Column<Guid>(type: "uuid", nullable: false),
                    TrainingUnitUnitCode = table.Column<Guid>(type: "uuid", nullable: false),
                    OutputStandardId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingContents", x => x.TrainingContentId);
                    table.ForeignKey(
                        name: "FK_TrainingContents_OutputStandard_OutputStandardId",
                        column: x => x.OutputStandardId,
                        principalTable: "OutputStandard",
                        principalColumn: "OutputStandardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingContents_TrainingUnits_TrainingUnitUnitCode",
                        column: x => x.TrainingUnitUnitCode,
                        principalTable: "TrainingUnits",
                        principalColumn: "UnitCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingMaterials",
                columns: table => new
                {
                    Fileupload = table.Column<string>(type: "text", nullable: false),
                    Unitcode = table.Column<string>(type: "text", nullable: true),
                    TrainingUnitUnitCode = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingMaterials", x => x.Fileupload);
                    table.ForeignKey(
                        name: "FK_TrainingMaterials_TrainingUnits_TrainingUnitUnitCode",
                        column: x => x.TrainingUnitUnitCode,
                        principalTable: "TrainingUnits",
                        principalColumn: "UnitCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    Usertype = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassUsers", x => new { x.ClassId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ClassUsers_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningObjectives",
                columns: table => new
                {
                    LearningObjectiveCode = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TrainingContentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningObjectives", x => x.LearningObjectiveCode);
                    table.ForeignKey(
                        name: "FK_LearningObjectives_TrainingContents_TrainingContentId",
                        column: x => x.TrainingContentId,
                        principalTable: "TrainingContents",
                        principalColumn: "TrainingContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningObjectiveSyllabus",
                columns: table => new
                {
                    LearningObjectivesLearningObjectiveCode = table.Column<Guid>(type: "uuid", nullable: false),
                    SyllabusesSyllabusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningObjectiveSyllabus", x => new { x.LearningObjectivesLearningObjectiveCode, x.SyllabusesSyllabusId });
                    table.ForeignKey(
                        name: "FK_LearningObjectiveSyllabus_LearningObjectives_LearningObject~",
                        column: x => x.LearningObjectivesLearningObjectiveCode,
                        principalTable: "LearningObjectives",
                        principalColumn: "LearningObjectiveCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningObjectiveSyllabus_Syllabuses_SyllabusesSyllabusId",
                        column: x => x.SyllabusesSyllabusId,
                        principalTable: "Syllabuses",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Createdat", "Email", "Gender", "Name", "Password", "Phone", "RoleId", "Status", "UpdateAt" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000012345"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FAMS@gmail.com", null, "Admin FAMS", "$2a$11$5rrlnh5BJOlKBTMsrv1jT.2Qj462vbtWc5subwcLR4tPiy1ma.QKe", null, 1, "Inactive", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AsessmentScheme_SyllabusId",
                table: "AsessmentScheme",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_TrainingProgramCode",
                table: "Class",
                column: "TrainingProgramCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClassUsers_UserId",
                table: "ClassUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningObjectives_TrainingContentId",
                table: "LearningObjectives",
                column: "TrainingContentId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningObjectiveSyllabus_SyllabusesSyllabusId",
                table: "LearningObjectiveSyllabus",
                column: "SyllabusesSyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_RolesId",
                table: "PermissionRole",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabuses_CreatedByUserId",
                table: "Syllabuses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingContents_OutputStandardId",
                table: "TrainingContents",
                column: "OutputStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingContents_TrainingUnitUnitCode",
                table: "TrainingContents",
                column: "TrainingUnitUnitCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingMaterials_TrainingUnitUnitCode",
                table: "TrainingMaterials",
                column: "TrainingUnitUnitCode");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPrograms_UserId",
                table: "TrainingPrograms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgramSyllabuses_SyllabusId",
                table: "TrainingProgramSyllabuses",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgramSyllabuses_TrainingProgramCode1",
                table: "TrainingProgramSyllabuses",
                column: "TrainingProgramCode1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingUnits_SyllabusId",
                table: "TrainingUnits",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsessmentScheme");

            migrationBuilder.DropTable(
                name: "ClassUsers");

            migrationBuilder.DropTable(
                name: "LearningObjectiveSyllabus");

            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropTable(
                name: "TrainingMaterials");

            migrationBuilder.DropTable(
                name: "TrainingProgramSyllabuses");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "LearningObjectives");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "TrainingPrograms");

            migrationBuilder.DropTable(
                name: "TrainingContents");

            migrationBuilder.DropTable(
                name: "OutputStandard");

            migrationBuilder.DropTable(
                name: "TrainingUnits");

            migrationBuilder.DropTable(
                name: "Syllabuses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
