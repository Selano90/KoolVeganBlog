using Microsoft.EntityFrameworkCore.Migrations;

namespace KoolVeganBlog.Migrations
{
    public partial class removedAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_Authors_AuthorId",
                table: "MainComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Authors_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_Authors_AuthorId",
                table: "SubComment");

            migrationBuilder.DropIndex(
                name: "IX_SubComment_AuthorId",
                table: "SubComment");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_MainComments_AuthorId",
                table: "MainComments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "SubComment");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "MainComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "SubComment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "MainComments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubComment_AuthorId",
                table: "SubComment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MainComments_AuthorId",
                table: "MainComments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_Authors_AuthorId",
                table: "MainComments",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Authors_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_Authors_AuthorId",
                table: "SubComment",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
