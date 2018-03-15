using CookingSchool.WebApi.Utils;
using Xunit;

namespace CookingSchoolTest
{
    public class FileNameHelperTests
    {
        public class WhenGetCleanFileNameIsCalled : FileNameHelperTests
        {
            private FileNameHelper _helper;

            public WhenGetCleanFileNameIsCalled()
            {
                _helper = new FileNameHelper();
            }

            [Theory]
            [InlineData("orange", "orange")]
            [InlineData("\"orange\"", "orange")]
            [InlineData("\"orange", "orange")]
            [InlineData("\"ora\"nge\"", "orange")]
            [InlineData("", "NoName")]

            public void ItShouldReturnExpectedTest(string actualText, string expectedText)
            {
                //Act
                var result = _helper.GetCleanFileName(actualText);

                //Assert
                Assert.Equal(expectedText, result);
            }
        }
    }
}
