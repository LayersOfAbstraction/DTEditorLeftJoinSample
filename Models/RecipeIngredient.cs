namespace DTEditorLeftJoinSample.Models
{
    public class RecipeIngredient
    {
        public int ID { get; set; }

        [Display(Name = "Recipe ID")]
        public int RecipeID { get; set; }

        [Display(Name = "Ingredient ID")]
        public int IngredientID { get; set; }

        public int Quantity { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
