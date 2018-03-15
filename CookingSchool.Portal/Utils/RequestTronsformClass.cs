using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookingSchool.Portal.Utils
{
    public static class RequestTronsformClass
    {
        internal static void CopyHeadersFrom(this System.Net.Http.HttpRequestMessage message, HttpRequestBase request)
        {
            foreach (string headerName in request.Headers)
            {
                string[] headerValues = request.Headers.GetValues(headerName);
                if (!message.Headers.TryAddWithoutValidation(headerName, headerValues))
                {
                    message.Content.Headers.TryAddWithoutValidation(headerName, headerValues);
                }
            }
        }
    }
}