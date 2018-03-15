using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookingSchool.WebApi.Models
{
    public class EditAuthorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string Job { get; set; }
    }
}