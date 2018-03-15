using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingSchool.WebApi.Utils
{
    public interface IFileNameHelper
    {
        string GetCleanFileName(string fileName);
    }
}
