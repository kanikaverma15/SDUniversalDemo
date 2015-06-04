using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDUniversalDemo.API
{
    public class JsonParser
    {
        public static T ObjectDeserializer<T>(string response)
        {
            JObject json = JObject.Parse(response);
            JsonSerializer serializer = new JsonSerializer();
            return serializer.Deserialize<T>(new JTokenReader(json)); ;
        }
    }
}
