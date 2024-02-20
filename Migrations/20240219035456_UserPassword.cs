using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FAMS.Migrations
{
    public partial class UserPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    permissionid = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.permissionid);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permissionrole",
                columns: table => new
                {
                    permissionid = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    roleid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("permissionrole_pkey", x => new { x.permissionid, x.roleid });
                    table.ForeignKey(
                        name: "permissionrole_permissionid_fkey",
                        column: x => x.permissionid,
                        principalTable: "permissions",
                        principalColumn: "permissionid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "permissionrole_roleid_fkey",
                        column: x => x.roleid,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    dob = table.Column<DateTime>(type: "date", nullable: true),
                    gender = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    roleid = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updateat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "users_roleid_fkey",
                        column: x => x.roleid,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "syllabus",
                columns: table => new
                {
                    topiccode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    topicname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    version = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    level = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    trainingaudience = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    technicalrequirement = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    courseobjective = table.Column<string>(type: "text", nullable: true),
                    timelocation = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    deliveryprinciple = table.Column<string>(type: "text", nullable: true),
                    createdby = table.Column<Guid>(type: "uuid", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true),
                    modifiedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("syllabus_pkey", x => x.topiccode);
                    table.ForeignKey(
                        name: "syllabus_createdby_fkey",
                        column: x => x.createdby,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trainingprogram",
                columns: table => new
                {
                    trainingprogramcode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: true),
                    duration = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    topiccode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    createdby = table.Column<Guid>(type: "uuid", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true),
                    modifiedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("trainingprogram_pkey", x => x.trainingprogramcode);
                    table.ForeignKey(
                        name: "trainingprogram_userid_fkey",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AsessmentScheme",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quiz = table.Column<int>(type: "integer", nullable: true),
                    assigment = table.Column<int>(type: "integer", nullable: true),
                    final = table.Column<int>(type: "integer", nullable: true),
                    finaltheory = table.Column<int>(type: "integer", nullable: true),
                    finalpratical = table.Column<int>(type: "integer", nullable: true),
                    gpa = table.Column<int>(type: "integer", nullable: true),
                    topiccode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsessmentScheme", x => x.id);
                    table.ForeignKey(
                        name: "AsessmentScheme_topiccode_fkey",
                        column: x => x.topiccode,
                        principalTable: "syllabus",
                        principalColumn: "topiccode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingUnit",
                columns: table => new
                {
                    unitcode = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    unitname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    daynumber = table.Column<int>(type: "integer", nullable: true),
                    topiccode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TrainingUnit_pkey", x => x.unitcode);
                    table.ForeignKey(
                        name: "TrainingUnit_topiccode_fkey",
                        column: x => x.topiccode,
                        principalTable: "syllabus",
                        principalColumn: "topiccode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    classid = table.Column<Guid>(type: "uuid", nullable: false),
                    trainprogramcode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    classname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    classcode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    duration = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    status = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    location = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    fsu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    startdate = table.Column<DateTime>(type: "date", nullable: true),
                    enddate = table.Column<DateTime>(type: "date", nullable: true),
                    createdby = table.Column<Guid>(type: "uuid", nullable: true),
                    createdat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modifiedby = table.Column<Guid>(type: "uuid", nullable: true),
                    modifiedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.classid);
                    table.ForeignKey(
                        name: "class_createdby_fkey",
                        column: x => x.createdby,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "class_trainprogramcode_fkey",
                        column: x => x.trainprogramcode,
                        principalTable: "trainingprogram",
                        principalColumn: "trainingprogramcode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgramSyllabus",
                columns: table => new
                {
                    topiccode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    trainingprogramcode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    sequence = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TrainingProgramSyllabus_pkey", x => new { x.topiccode, x.trainingprogramcode });
                    table.ForeignKey(
                        name: "TrainingProgramSyllabus_topiccode_fkey",
                        column: x => x.topiccode,
                        principalTable: "syllabus",
                        principalColumn: "topiccode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "TrainingProgramSyllabus_trainingprogramcode_fkey",
                        column: x => x.trainingprogramcode,
                        principalTable: "trainingprogram",
                        principalColumn: "trainingprogramcode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingContent",
                columns: table => new
                {
                    contentname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    outputstandard = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    trainingtime = table.Column<int>(type: "integer", nullable: true),
                    method = table.Column<bool>(type: "boolean", nullable: true),
                    deliverytype = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    unitcode = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "TrainingContent_unitcode_fkey",
                        column: x => x.unitcode,
                        principalTable: "TrainingUnit",
                        principalColumn: "unitcode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingMaterial",
                columns: table => new
                {
                    fileupload = table.Column<string>(type: "text", nullable: true),
                    unitcode = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "TrainingMaterial_unitcode_fkey",
                        column: x => x.unitcode,
                        principalTable: "TrainingUnit",
                        principalColumn: "unitcode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassUser",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    classid = table.Column<Guid>(type: "uuid", nullable: false),
                    usertype = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ClassUser_pkey", x => new { x.userid, x.classid });
                    table.ForeignKey(
                        name: "ClassUser_classid_fkey",
                        column: x => x.classid,
                        principalTable: "class",
                        principalColumn: "classid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ClassUser_userid_fkey",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsessmentScheme_topiccode",
                table: "AsessmentScheme",
                column: "topiccode");

            migrationBuilder.CreateIndex(
                name: "IX_class_createdby",
                table: "class",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_class_trainprogramcode",
                table: "class",
                column: "trainprogramcode");

            migrationBuilder.CreateIndex(
                name: "IX_ClassUser_classid",
                table: "ClassUser",
                column: "classid");

            migrationBuilder.CreateIndex(
                name: "IX_permissionrole_roleid",
                table: "permissionrole",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_syllabus_createdby",
                table: "syllabus",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "TrainingContent_unitcode_key",
                table: "TrainingContent",
                column: "unitcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TrainingMaterial_unitcode_key",
                table: "TrainingMaterial",
                column: "unitcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainingprogram_userid",
                table: "trainingprogram",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgramSyllabus_trainingprogramcode",
                table: "TrainingProgramSyllabus",
                column: "trainingprogramcode");

            migrationBuilder.CreateIndex(
                name: "TrainingUnit_topiccode_key",
                table: "TrainingUnit",
                column: "topiccode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_roleid",
                table: "users",
                column: "roleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsessmentScheme");

            migrationBuilder.DropTable(
                name: "ClassUser");

            migrationBuilder.DropTable(
                name: "permissionrole");

            migrationBuilder.DropTable(
                name: "TrainingContent");

            migrationBuilder.DropTable(
                name: "TrainingMaterial");

            migrationBuilder.DropTable(
                name: "TrainingProgramSyllabus");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "TrainingUnit");

            migrationBuilder.DropTable(
                name: "trainingprogram");

            migrationBuilder.DropTable(
                name: "syllabus");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
