using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace Core
{
    using NewSerializer = System.Text.Json.JsonSerializer;

    public class SerializeHelper
    {
        public IEnumerable<T> ReadAsIEnumerable<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            return obj;
        }

        public T Read<T>(string json) where T : class
        {
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        public string ToJsonString<T>(IEnumerable<T> obj)
        {
            var str = JsonConvert.SerializeObject(obj);
            return str;
        }

        public string ToJsonString<T>(T obj)
        {
            var str = JsonConvert.SerializeObject(obj);
            return str;
        }
    }
}
