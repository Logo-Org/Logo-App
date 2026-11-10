using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LogoAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IssueType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    VideoRecording = table.Column<byte[]>(type: "bytea", nullable: true),
                    AudioRecording = table.Column<byte[]>(type: "bytea", nullable: true),
                    IssueStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Response = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    Contact_Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Contact_PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    AccountStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    JoinDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SpeechTherapistId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Links = table.Column<HashSet<string>>(type: "text[]", nullable: true),
                    Address_City = table.Column<string>(type: "text", nullable: true),
                    Address_Country = table.Column<string>(type: "text", nullable: true),
                    Address_Street = table.Column<string>(type: "text", nullable: true),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Person_SpeechTherapistId",
                        column: x => x.SpeechTherapistId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    BodyPartCategory = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DisorderCategory = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SpeechSoundCategory = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminUser",
                columns: table => new
                {
                    AdminsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUser", x => new { x.AdminsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AdminUser_Person_AdminsId",
                        column: x => x.AdminsId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminUser_Person_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Document = table.Column<byte[]>(type: "bytea", nullable: false),
                    SpeechTherapistId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credential_Person_SpeechTherapistId",
                        column: x => x.SpeechTherapistId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VideoRecordingInstruction = table.Column<byte[]>(type: "bytea", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    StepByStepInstruction = table.Column<List<string>>(type: "text[]", nullable: true),
                    AdminId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Person_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TherapyPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GoalDescription = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapyPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TherapyPlan_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTag",
                columns: table => new
                {
                    ExercisesId = table.Column<long>(type: "bigint", nullable: false),
                    TagsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTag", x => new { x.ExercisesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ExerciseTag_Exercise_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisorderTherapyPlan",
                columns: table => new
                {
                    DisordersId = table.Column<long>(type: "bigint", nullable: false),
                    TherapyPlansId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisorderTherapyPlan", x => new { x.DisordersId, x.TherapyPlansId });
                    table.ForeignKey(
                        name: "FK_DisorderTherapyPlan_Tag_DisordersId",
                        column: x => x.DisordersId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisorderTherapyPlan_TherapyPlan_TherapyPlansId",
                        column: x => x.TherapyPlansId,
                        principalTable: "TherapyPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Series = table.Column<int>(type: "integer", nullable: false),
                    Repetition = table.Column<int>(type: "integer", nullable: false),
                    TaskStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PeriodStartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PeriodEndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaxSessionPerPeriod = table.Column<int>(type: "integer", nullable: false),
                    TherapyPlanId = table.Column<long>(type: "bigint", nullable: false),
                    ExerciseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_TherapyPlan_TherapyPlanId",
                        column: x => x.TherapyPlanId,
                        principalTable: "TherapyPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TherapyStage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TherapyStageStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TherapyPlanId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapyStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TherapyStage_TherapyPlan_TherapyPlanId",
                        column: x => x.TherapyPlanId,
                        principalTable: "TherapyPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskId = table.Column<long>(type: "bigint", nullable: false),
                    IssueId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Session_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminUser_UsersId",
                table: "AdminUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Credential_SpeechTherapistId",
                table: "Credential",
                column: "SpeechTherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_DisorderTherapyPlan_TherapyPlansId",
                table: "DisorderTherapyPlan",
                column: "TherapyPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_AdminId",
                table: "Exercise",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseTag_TagsId",
                table: "ExerciseTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_SpeechTherapistId",
                table: "Person",
                column: "SpeechTherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_IssueId",
                table: "Session",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_TaskId",
                table: "Session",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ExerciseId",
                table: "Task",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TherapyPlanId",
                table: "Task",
                column: "TherapyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapyPlan_PatientId",
                table: "TherapyPlan",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapyStage_TherapyPlanId",
                table: "TherapyStage",
                column: "TherapyPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUser");

            migrationBuilder.DropTable(
                name: "Credential");

            migrationBuilder.DropTable(
                name: "DisorderTherapyPlan");

            migrationBuilder.DropTable(
                name: "ExerciseTag");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "TherapyStage");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "TherapyPlan");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
