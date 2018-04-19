using System;
using System.Collections.Generic;
using Xunit;

namespace CookingSchool.Tests.Misc
{
    public class ObjectTests
    {
        [Fact]
        public void JasiekHashDictionary()
        {
            var dictionary = new JsiekHashDictionary();

            dictionary.InsertUsingKeyPairValue("glupek","wiecinski");

            var result = dictionary.DisplayUsingKeyPairValue("glupek");

            Assert.Equal("wiecinski", result);

        }
    }
}
