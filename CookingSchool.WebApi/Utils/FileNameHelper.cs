namespace CookingSchool.WebApi.Utils
{
    public class FileNameHelper : IFileNameHelper
    {
        public string GetCleanFileName(string fileName)
        {
            var name = !string.IsNullOrWhiteSpace(fileName)
               ? fileName : "NoName";
            name = name.Replace("\"", string.Empty);
            return name;
        }
    }
}