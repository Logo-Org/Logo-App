using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogoAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_Task_TherapyTaskId",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Exercise_ExerciseId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_TherapyPlan_TherapyPlanId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "TherapyTasks");

            migrationBuilder.RenameIndex(
                name: "IX_Task_TherapyPlanId",
                table: "TherapyTasks",
                newName: "IX_TherapyTasks_TherapyPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ExerciseId",
                table: "TherapyTasks",
                newName: "IX_TherapyTasks_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TherapyTasks",
                table: "TherapyTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_TherapyTasks_TherapyTaskId",
                table: "Session",
                column: "TherapyTaskId",
                principalTable: "TherapyTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TherapyTasks_Exercise_ExerciseId",
                table: "TherapyTasks",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TherapyTasks_TherapyPlan_TherapyPlanId",
                table: "TherapyTasks",
                column: "TherapyPlanId",
                principalTable: "TherapyPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_TherapyTasks_TherapyTaskId",
                table: "Session");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapyTasks_Exercise_ExerciseId",
                table: "TherapyTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TherapyTasks_TherapyPlan_TherapyPlanId",
                table: "TherapyTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TherapyTasks",
                table: "TherapyTasks");

            migrationBuilder.RenameTable(
                name: "TherapyTasks",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_TherapyTasks_TherapyPlanId",
                table: "Task",
                newName: "IX_Task_TherapyPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_TherapyTasks_ExerciseId",
                table: "Task",
                newName: "IX_Task_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Task_TherapyTaskId",
                table: "Session",
                column: "TherapyTaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Exercise_ExerciseId",
                table: "Task",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TherapyPlan_TherapyPlanId",
                table: "Task",
                column: "TherapyPlanId",
                principalTable: "TherapyPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
