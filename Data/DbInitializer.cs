namespace DTEditorLeftJoinSample.Data
{
    public class DbInitializer
    {
        public static void Initialize(CookingContext context)
        {
            

            // Look for any tables.
            if (context.Recipe.Any() && context.Ingredient.Any() && context.RecipeIngredient.Any())
            {
                return;   // DB has been seeded
            }

            var recipes = new Recipe[]
            {
                new Recipe { Title =" Korean-Style Steak and Noodles with Kimchi",
                Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sed pharetra neque. Curabitur laoreet eu lectus eu tempus. Fusce elementum arcu ut justo tincidunt mattis.",
                Direction="1.Cras dignissim in neque a placerat." + "\r\n" + "2.Vestibulum vel vestibulum nunc." + "\r\n" +  "3. Vestibulum interdum est tellus, nec porta metus dignissim ut."
                },
                new Recipe { Title =" Mashed Potatoes with Savory Thyme Granola",
                Description=" Etiam aliquam, magna quis lobortis facilisis, lorem eros dignissim nulla, ultrices pulvinar orci lectus a ligula.",
                Direction="1. Morbi fringilla, justo eu venenatis tempus, mauris leo ultricies magna, et aliquet mi lectus at nisi. Pellentesque vel gravida nunc. Donec in tortor lectus." + "\r\n" + "2.Vestibulum vel vestibulum nunc." + "\r\n" +  "3. Vestibulum interdum est tellus, nec porta metus dignissim ut."},
                new Recipe { Title ="Lemon Garlic Mashed Potatoes",
                Description="Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.",
                Direction="1. Maecenas ultricies pretium quam id placerat. Mauris in ligula gravida, vehicula justo faucibus, semper neque." + "\r\n" + "2. Proin sodales aliquam erat quis venenatis." + "\r\n" +  "3. Morbi consectetur libero id sagittis vestibulum."},
                new Recipe { Title =" Sour Cream and Corn Mashers",
                Description=" Donec posuere pellentesque mi, ac suscipit tellus finibus id.",
                Direction="1. Nulla placerat erat lorem, eget pellentesque dolor egestas vitae." + "\r\n" + "2. Proin sodales aliquam erat quis venenatis." + "\r\n" +  "3. Suspendisse ac purus lacinia, mollis velit aliquet, finibus arcu. Pellentesque molestie est in diam pulvinar, quis mattis justo volutpat."}
                            };
            foreach (Recipe r in recipes)
            {
                context.Recipe.AddRange(r);
            }
            context.SaveChanges();

            var ingredients = new Ingredient[]
            {
                new Ingredient{IngredientName="Duis eu ligula felis"},
                new Ingredient{IngredientName="Donec id mollis arcu"},
                new Ingredient{IngredientName="Cras nec enim luctus"}
            };
            foreach (Ingredient i in ingredients)
            {
                context.Ingredient.AddRange(i);
            }
            context.SaveChanges();

            var recipeIngredients = new RecipeIngredient[]
            {
                new RecipeIngredient{RecipeID=1, IngredientID=1, Quantity =4},
                new RecipeIngredient{RecipeID=2, IngredientID=2, Quantity =3},
                new RecipeIngredient{RecipeID=3, IngredientID=3, Quantity =15}
            };

            foreach (RecipeIngredient ri in recipeIngredients)
            {
                context.RecipeIngredient.AddRange(ri);
            }
            context.SaveChanges();
        }

    }
}