using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class newcoloumnpdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookPdfUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookGallery_BookId",
                table: "BookGallery",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_Books_BookId",
                table: "BookGallery",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_Books_BookId",
                table: "BookGallery");

            migrationBuilder.DropIndex(
                name: "IX_BookGallery_BookId",
                table: "BookGallery");

            migrationBuilder.DropColumn(
                name: "BookPdfUrl",
                table: "Books");
        }
    }
}
