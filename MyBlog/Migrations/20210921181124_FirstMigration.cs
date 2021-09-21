using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbBlogCategories",
                columns: table => new
                {
                    TbBlogCategoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbBlogCategories", x => x.TbBlogCategoriesId);
                });

            migrationBuilder.CreateTable(
                name: "TbBlog",
                columns: table => new
                {
                    TbBlogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BlogContent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BlogImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryTbBlogCategoriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbBlog", x => x.TbBlogId);
                    table.ForeignKey(
                        name: "FK_TbBlog_TbBlogCategories_CategoryTbBlogCategoriesId",
                        column: x => x.CategoryTbBlogCategoriesId,
                        principalTable: "TbBlogCategories",
                        principalColumn: "TbBlogCategoriesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbBlogComments",
                columns: table => new
                {
                    TbBlogCommentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbBlogComments", x => x.TbBlogCommentsId);
                    table.ForeignKey(
                        name: "FK_TbBlogComments_TbBlog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "TbBlog",
                        principalColumn: "TbBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbBlogImages",
                columns: table => new
                {
                    TbBlogImagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbBlogImages", x => x.TbBlogImagesId);
                    table.ForeignKey(
                        name: "FK_TbBlogImages_TbBlog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "TbBlog",
                        principalColumn: "TbBlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbBlog_CategoryTbBlogCategoriesId",
                table: "TbBlog",
                column: "CategoryTbBlogCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_TbBlogComments_BlogId",
                table: "TbBlogComments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_TbBlogImages_BlogId",
                table: "TbBlogImages",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbBlogComments");

            migrationBuilder.DropTable(
                name: "TbBlogImages");

            migrationBuilder.DropTable(
                name: "TbBlog");

            migrationBuilder.DropTable(
                name: "TbBlogCategories");
        }
    }
}
