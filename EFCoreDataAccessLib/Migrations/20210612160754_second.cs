using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreDataAccessLib.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_quizzes_Quizid",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_Quizid",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "Quizid",
                table: "questions");

            migrationBuilder.RenameColumn(
                name: "goodAnswer",
                table: "questions",
                newName: "goodanswer");

            migrationBuilder.RenameColumn(
                name: "badAnswer3",
                table: "questions",
                newName: "badanswer3");

            migrationBuilder.RenameColumn(
                name: "badAnswer2",
                table: "questions",
                newName: "badanswer2");

            migrationBuilder.RenameColumn(
                name: "badAnswer1",
                table: "questions",
                newName: "badanswer1");

            migrationBuilder.CreateTable(
                name: "QuestionQuiz",
                columns: table => new
                {
                    questionsid = table.Column<int>(type: "int", nullable: false),
                    quizesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionQuiz", x => new { x.questionsid, x.quizesid });
                    table.ForeignKey(
                        name: "FK_QuestionQuiz_questions_questionsid",
                        column: x => x.questionsid,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionQuiz_quizzes_quizesid",
                        column: x => x.quizesid,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionQuiz_quizesid",
                table: "QuestionQuiz",
                column: "quizesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionQuiz");

            migrationBuilder.RenameColumn(
                name: "goodanswer",
                table: "questions",
                newName: "goodAnswer");

            migrationBuilder.RenameColumn(
                name: "badanswer3",
                table: "questions",
                newName: "badAnswer3");

            migrationBuilder.RenameColumn(
                name: "badanswer2",
                table: "questions",
                newName: "badAnswer2");

            migrationBuilder.RenameColumn(
                name: "badanswer1",
                table: "questions",
                newName: "badAnswer1");

            migrationBuilder.AddColumn<int>(
                name: "Quizid",
                table: "questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_questions_Quizid",
                table: "questions",
                column: "Quizid");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_quizzes_Quizid",
                table: "questions",
                column: "Quizid",
                principalTable: "quizzes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
