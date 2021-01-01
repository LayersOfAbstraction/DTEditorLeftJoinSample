using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DTEditorLeftJoinSample.Data;
using DTEditorLeftJoinSample.Models;
using DataTables;
using Microsoft.Extensions.Configuration;

namespace DTEditorLeftJoinSample.Controllers
{
    public class RecipeIngredientsController : Controller
    {
        private readonly CookingContext _context;


        private readonly IConfiguration _config;

        public RecipeIngredientsController(CookingContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: RecipeIngredients
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LeftJoinRecipesAndIngredientsOntoRecipeIngredient()
        {
            //DECLARE database connection.
            string connectionString = _config.GetConnectionString("DefaultConnection");
            //CREATE debatable instance.
            using (var db = new Database("sqlserver", connectionString))
            {
                //CREATE Editor instance with starting table.
                var response = new Editor(db, "tblRecipeIngredient")
                    .Field(new Field("tblRecipeIngredient.Quantity"))
                    .Field(new Field("tblRecipe.Description"))                     
                    .Field(new Field("tblIngredient.IngredientName"))
                     //JOIN from tblIngredient column RecipeID linked from tblRecipe column ID
                    //and IngredientID linked from tblUser column ID.                    
                    .LeftJoin("tblRecipe ", " tblRecipe.ID ", "=", " tblRecipeIngredient.RecipeID")
                    .LeftJoin("tblIngredient ", " tblIngredient.ID ", "=", " tblRecipeIngredient.IngredientID")
                    .Process(HttpContext.Request)
                    .Data();
                return Json(response);
            }
        }


        // GET: RecipeIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIngredient = await _context.RecipeIngredient
                .Include(r => r.Ingredient)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            return View(recipeIngredient);
        }

        // GET: RecipeIngredients/Create
        public IActionResult Create()
        {
            ViewData["IngredientID"] = new SelectList(_context.Ingredient, "ID", "ID");
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "ID", "ID");
            return View();
        }

        // POST: RecipeIngredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RecipeID,IngredientID,Quantity")] RecipeIngredient recipeIngredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientID"] = new SelectList(_context.Ingredient, "ID", "ID", recipeIngredient.IngredientID);
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "ID", "ID", recipeIngredient.RecipeID);
            return View(recipeIngredient);
        }

        // GET: RecipeIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIngredient = await _context.RecipeIngredient.FindAsync(id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }
            ViewData["IngredientID"] = new SelectList(_context.Ingredient, "ID", "ID", recipeIngredient.IngredientID);
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "ID", "ID", recipeIngredient.RecipeID);
            return View(recipeIngredient);
        }

        // POST: RecipeIngredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RecipeID,IngredientID,Quantity")] RecipeIngredient recipeIngredient)
        {
            if (id != recipeIngredient.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeIngredientExists(recipeIngredient.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientID"] = new SelectList(_context.Ingredient, "ID", "ID", recipeIngredient.IngredientID);
            ViewData["RecipeID"] = new SelectList(_context.Recipe, "ID", "ID", recipeIngredient.RecipeID);
            return View(recipeIngredient);
        }

        // GET: RecipeIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeIngredient = await _context.RecipeIngredient
                .Include(r => r.Ingredient)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            return View(recipeIngredient);
        }

        // POST: RecipeIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeIngredient = await _context.RecipeIngredient.FindAsync(id);
            _context.RecipeIngredient.Remove(recipeIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeIngredientExists(int id)
        {
            return _context.RecipeIngredient.Any(e => e.ID == id);
        }
    }
}
