using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FAMS.Migrations
{
    public partial class FAMS01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningObjectiveSyllabus_Syllabuses_SyllabusesTopicCode",
                table: "LearningObjectiveSyllabus");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingProgramSyllabuses_Syllabuses_SyllabusTopicCode",
                table: "TrainingProgramSyllabuses");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingUnits_Syllabuses_SyllabusTopicCode",
                table: "TrainingUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Syllabuses",
                table: "Syllabuses");

            migrationBuilder.DropColumn(
                name: "OutputStandard",
                table: "TrainingContents");

            migrationBuilder.RenameColumn(
                name: "SyllabusTopicCode",
                table: "TrainingUnits",
                newName: "SyllabusId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingUnits_SyllabusTopicCode",
                table: "TrainingUnits",
                newName: "IX_TrainingUnits_SyllabusId");

            migrationBuilder.RenameColumn(
                name: "SyllabusTopicCode",
                table: "TrainingProgramSyllabuses",
                newName: "SyllabusId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingProgramSyllabuses_SyllabusTopicCode",
                table: "TrainingProgramSyllabuses",
                newName: "IX_TrainingProgramSyllabuses_SyllabusId");

            migrationBuilder.RenameColumn(
                name: "SyllabusesTopicCode",
                table: "LearningObjectiveSyllabus",
                newName: "SyllabusesSyllabusId");

            migrationBuilder.RenameIndex(
                name: "IX_LearningObjectiveSyllabus_SyllabusesTopicCode",
                table: "LearningObjectiveSyllabus",
                newName: "IX_LearningObjectiveSyllabus_SyllabusesSyllabusId");

            migrationBuilder.AddColumn<Guid>(
                name: "OutputStandardId",
                table: "TrainingContents",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TopicCode",
                table: "Syllabuses",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "SyllabusId",
                table: "Syllabuses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Syllabuses",
                table: "Syllabuses",
                column: "SyllabusId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TrainingContents_OutputStandardId",
                table: "TrainingContents",
                column: "OutputStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_AsessmentScheme_SyllabusId",
                table: "AsessmentScheme",
                column: "SyllabusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningObjectiveSyllabus_Syllabuses_SyllabusesSyllabusId",
                table: "LearningObjectiveSyllabus",
                column: "SyllabusesSyllabusId",
                principalTable: "Syllabuses",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingContents_OutputStandard_OutputStandardId",
                table: "TrainingContents",
                column: "OutputStandardId",
                principalTable: "OutputStandard",
                principalColumn: "OutputStandardId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingProgramSyllabuses_Syllabuses_SyllabusId",
                table: "TrainingProgramSyllabuses",
                column: "SyllabusId",
                principalTable: "Syllabuses",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingUnits_Syllabuses_SyllabusId",
                table: "TrainingUnits",
                column: "SyllabusId",
                principalTable: "Syllabuses",
                principalColumn: "SyllabusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LearningObjectiveSyllabus_Syllabuses_SyllabusesSyllabusId",
                table: "LearningObjectiveSyllabus");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingContents_OutputStandard_OutputStandardId",
                table: "TrainingContents");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingProgramSyllabuses_Syllabuses_SyllabusId",
                table: "TrainingProgramSyllabuses");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingUnits_Syllabuses_SyllabusId",
                table: "TrainingUnits");

            migrationBuilder.DropTable(
                name: "AsessmentScheme");

            migrationBuilder.DropTable(
                name: "OutputStandard");

            migrationBuilder.DropIndex(
                name: "IX_TrainingContents_OutputStandardId",
                table: "TrainingContents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Syllabuses",
                table: "Syllabuses");

            migrationBuilder.DropColumn(
                name: "OutputStandardId",
                table: "TrainingContents");

            migrationBuilder.DropColumn(
                name: "SyllabusId",
                table: "Syllabuses");

            migrationBuilder.RenameColumn(
                name: "SyllabusId",
                table: "TrainingUnits",
                newName: "SyllabusTopicCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingUnits_SyllabusId",
                table: "TrainingUnits",
                newName: "IX_TrainingUnits_SyllabusTopicCode");

            migrationBuilder.RenameColumn(
                name: "SyllabusId",
                table: "TrainingProgramSyllabuses",
                newName: "SyllabusTopicCode");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingProgramSyllabuses_SyllabusId",
                table: "TrainingProgramSyllabuses",
                newName: "IX_TrainingProgramSyllabuses_SyllabusTopicCode");

            migrationBuilder.RenameColumn(
                name: "SyllabusesSyllabusId",
                table: "LearningObjectiveSyllabus",
                newName: "SyllabusesTopicCode");

            migrationBuilder.RenameIndex(
                name: "IX_LearningObjectiveSyllabus_SyllabusesSyllabusId",
                table: "LearningObjectiveSyllabus",
                newName: "IX_LearningObjectiveSyllabus_SyllabusesTopicCode");

            migrationBuilder.AddColumn<string>(
                name: "OutputStandard",
                table: "TrainingContents",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TopicCode",
                table: "Syllabuses",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Syllabuses",
                table: "Syllabuses",
                column: "TopicCode");

            migrationBuilder.AddForeignKey(
                name: "FK_LearningObjectiveSyllabus_Syllabuses_SyllabusesTopicCode",
                table: "LearningObjectiveSyllabus",
                column: "SyllabusesTopicCode",
                principalTable: "Syllabuses",
                principalColumn: "TopicCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingProgramSyllabuses_Syllabuses_SyllabusTopicCode",
                table: "TrainingProgramSyllabuses",
                column: "SyllabusTopicCode",
                principalTable: "Syllabuses",
                principalColumn: "TopicCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingUnits_Syllabuses_SyllabusTopicCode",
                table: "TrainingUnits",
                column: "SyllabusTopicCode",
                principalTable: "Syllabuses",
                principalColumn: "TopicCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
