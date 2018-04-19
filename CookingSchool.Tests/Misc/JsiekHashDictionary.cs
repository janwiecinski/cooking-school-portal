using System;
using System.Collections;
using System.Collections.Generic;

namespace CookingSchool.Tests.Misc
{
    public class JsiekHashDictionary 
    {
        IList jasiekDictionary;
        ArrayList jasiekArray;
        IList stringValues;
        public JsiekHashDictionary()
        {
            jasiekDictionary = new List<KeyValuePair<int,string>>();
            stringValues = new List<string>();
            jasiekArray = new ArrayList(jasiekDictionary);
        }

        public void InsertUsingKeyPairValue(string paramKey, string paramValue)
        {
            var key = paramKey.GetHashCode();
            var keyValuePair = new KeyValuePair<int, string>(key, paramValue);
            jasiekDictionary.Add(keyValuePair);
        }

        public string DisplayUsingKeyPairValue(string paramKey)
        {
            var key = paramKey.GetHashCode();
            foreach( KeyValuePair<int,string> item in jasiekDictionary)
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
           throw new NullReferenceException();
        }

        public void InsertUsingArray(string paramKey, string paramValue)
        {
            var key = paramKey.GetHashCode();
            var abs = Math.Abs(key);
            jasiekArray[abs] = paramValue;
        }

        public string DisplayUsingArray(string paramKey)
        {
            var key = paramKey.GetHashCode();
            var abs = Math.Abs(key);
            if(jasiekArray[abs] != null)
            {
                return jasiekArray[abs].ToString();
            }
            throw new NullReferenceException();
        }
    }
}
