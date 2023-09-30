

namespace DTEditorLeftJoinSample.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        [Display(Name = "Ingredient Name")]
        public string IngredientName { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredient { get; set; }
    }
}
