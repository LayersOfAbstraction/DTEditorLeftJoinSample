using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTEditorLeftJoinSample.Models
{
	public class Recipe
	{
		public int ID { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }
		public string Direction { get; set; }

		public ICollection<RecipeIngredient> RecipeIngredient { get; set; }
	}
}
