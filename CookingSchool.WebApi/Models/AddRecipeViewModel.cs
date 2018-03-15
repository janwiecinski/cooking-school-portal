using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookingSchool.WebApi.Models
{
    public class AddRecipeViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }
    }
}