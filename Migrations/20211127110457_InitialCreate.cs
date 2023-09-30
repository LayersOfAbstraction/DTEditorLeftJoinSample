using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTEditorLeftJoinSample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblIngredient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIngredient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblRecipe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecipe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblRecipeIngredient ",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeID = table.Column<int>(type: "int", nullable: false),
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRecipeIngredient ", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblRecipeIngredient _tblIngredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "tblIngredient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRecipeIngredient _tblRecipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "tblRecipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblRecipeIngredient _IngredientID",
                table: "tblRecipeIngredient ",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_tblRecipeIngredient _RecipeID",
                table: "tblRecipeIngredient ",
                column: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblRecipeIngredient ");

            migrationBuilder.DropTable(
                name: "tblIngredient");

            migrationBuilder.DropTable(
                name: "tblRecipe");
        }
    }
}
