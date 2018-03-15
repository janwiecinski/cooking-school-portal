using CookingSchool.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace CookingSchool.DAL.Repositories
{
    public class RecipeRepository
    {

        CookingContext Context = new CookingContext();
        
        public List<Recipe> GetAll()
        {
            return Context.Recipes.ToList();
        }
        
       public void Delete(int id)
        {
            Recipe rec = Context.Recipes.Find(id);

            Context.Recipes.Remove(rec);

            Context.SaveChanges();

        }
    
    }
}
