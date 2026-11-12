using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogoAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminUser_Person_AdminsId",
                table: "AdminUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUser_Person_UsersId",
                table: "AdminUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Person_AdminId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_SpeechTherapistId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapyStage_TherapyPlan_TherapyPlanId",
                table: "TherapyStage");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapyTasks_Exercise_ExerciseId",
                table: "TherapyTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminUser",
                table: "AdminUser");

            migrationBuilder.RenameTable(
                name: "AdminUser",
                newName: "UserAdmin");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUser_UsersId",
                table: "UserAdmin",
                newName: "IX_UserAdmin_UsersId");

            migrationBuilder.AddColumn<long>(
                name: "SessionId",
                table: "TherapyTasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "TherapyPlanId",
                table: "TherapyStage",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TherapyStage",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "GoalDescription",
                table: "TherapyPlan",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "DisorderId",
                table: "TherapyPlan",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TherapyStageId",
                table: "TherapyPlan",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TherapyTaskId",
                table: "TherapyPlan",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Contact_Email",
                table: "Person",
                type: "character varying(254)",
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Address_ZipCode",
                table: "Person",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Street",
                table: "Person",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "Person",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_City",
                table: "Person",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "Person",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Response",
                table: "Issue",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Issue",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "TherapyTaskId",
                table: "Exercise",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Credential",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "Credential",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAdmin",
                table: "UserAdmin",
                columns: new[] { "AdminsId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Person_AdminId",
                table: "Exercise",
                column: "AdminId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_SpeechTherapistId",
                table: "Person",
                column: "SpeechTherapistId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TherapyStage_TherapyPlan_TherapyPlanId",
                table: "TherapyStage",
                column: "TherapyPlanId",
                principalTable: "TherapyPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TherapyTasks_Exercise_ExerciseId",
                table: "TherapyTasks",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdmin_Person_AdminsId",
                table: "UserAdmin",
                column: "AdminsId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdmin_Person_UsersId",
                table: "UserAdmin",
                column: "UsersId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Person_AdminId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_SpeechTherapistId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapyStage_TherapyPlan_TherapyPlanId",
                table: "TherapyStage");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapyTasks_Exercise_ExerciseId",
                table: "TherapyTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdmin_Person_AdminsId",
                table: "UserAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAdmin_Person_UsersId",
                table: "UserAdmin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAdmin",
                table: "UserAdmin");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "TherapyTasks");

            migrationBuilder.DropColumn(
                name: "DisorderId",
                table: "TherapyPlan");

            migrationBuilder.DropColumn(
                name: "TherapyStageId",
                table: "TherapyPlan");

            migrationBuilder.DropColumn(
                name: "TherapyTaskId",
                table: "TherapyPlan");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "TherapyTaskId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Credential");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "Credential");

            migrationBuilder.RenameTable(
                name: "UserAdmin",
                newName: "AdminUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserAdmin_UsersId",
                table: "AdminUser",
                newName: "IX_AdminUser_UsersId");

            migrationBuilder.AlterColumn<long>(
                name: "TherapyPlanId",
                table: "TherapyStage",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "TherapyStage",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GoalDescription",
                table: "TherapyPlan",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Contact_Email",
                table: "Person",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(254)",
                oldMaxLength: 254);

            migrationBuilder.AlterColumn<string>(
                name: "Address_ZipCode",
                table: "Person",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Street",
                table: "Person",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "Person",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address_City",
                table: "Person",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Response",
                table: "Issue",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Issue",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminUser",
                table: "AdminUser",
                columns: new[] { "AdminsId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUser_Person_AdminsId",
                table: "AdminUser",
                column: "AdminsId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUser_Person_UsersId",
                table: "AdminUser",
                column: "UsersId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Person_AdminId",
                table: "Exercise",
                column: "AdminId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_SpeechTherapistId",
                table: "Person",
                column: "SpeechTherapistId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TherapyStage_TherapyPlan_TherapyPlanId",
                table: "TherapyStage",
                column: "TherapyPlanId",
                principalTable: "TherapyPlan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TherapyTasks_Exercise_ExerciseId",
                table: "TherapyTasks",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
