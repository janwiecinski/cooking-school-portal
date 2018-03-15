using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingSchool.Portal.Utils
{
    public interface IFileNameHelper
    {
        string GetCleanFileName(string fileName);
    }
}
