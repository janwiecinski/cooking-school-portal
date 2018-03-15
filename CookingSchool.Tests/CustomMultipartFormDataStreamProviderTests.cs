using CookingSchool.WebApi.Providers;
using CookingSchool.WebApi.Utils;
using Moq;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace CookingSchoolTest
{
    public class CustomMultipartFormDataStreamProviderTests
    {
        public class WhenGetCleanFileNameIsCalled : FileNameHelperTests
        {
            private CustomMultipartFormDataStreamProvider _provider;
            private Mock<IFileNameHelper> _fileNameHelperMock;

            public WhenGetCleanFileNameIsCalled()
            {
                _fileNameHelperMock = new Mock<IFileNameHelper>();
                _provider = new CustomMultipartFormDataStreamProvider(_fileNameHelperMock.Object, @"C:\whatever");
            }

            [Fact]
            public void ItShouldCallFileNameHelperOnce()
            {
                //Arrange
                var content = new StringContent(string.Empty);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    FileName = "abc"
                };

                //Act
                var result = _provider.GetLocalFileName(content.Headers);

                //Assert
                _fileNameHelperMock.Verify(f => f.GetCleanFileName(content.Headers.ContentDisposition.FileName), Times.Once);
            }

            [Fact]
            public void ItShouldReturnLocalFileName()
            {
                //Arrange
                var content = new StringContent(string.Empty);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                var expectedFileName = "whatever";
                _fileNameHelperMock.Setup(f => f.GetCleanFileName(It.IsAny<string>())).Returns(expectedFileName);

                //Act
                var result = _provider.GetLocalFileName(content.Headers);

                //Assert
                Assert.Equal(expectedFileName, result);
            }
        }
    }
}
