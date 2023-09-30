
namespace DTEditorLeftJoinSample.Data
{
    public class CookingContext : DbContext
    {
        public CookingContext(DbContextOptions<CookingContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().ToTable("tblRecipe");
            modelBuilder.Entity<Ingredient>().ToTable("tblIngredient");
            modelBuilder.Entity<RecipeIngredient>().ToTable("tblRecipeIngredient ");
        }
    }
}
