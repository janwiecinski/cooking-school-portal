using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingSchool.DAL.Models
{
    public interface IRecipe
    {
         int Id { get; set; }
         string Title { get; set; }

         string Description { get; set; }

         string ImageName { get; set; }


    }
}
