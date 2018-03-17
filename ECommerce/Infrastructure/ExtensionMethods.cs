using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;

namespace ECommerce.Infrastructure
{
    public static class ExtensionMethods
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            var serializeObj = JsonConvert.SerializeObject(value);
            session.SetString(key, serializeObj);
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }

        

    }
}
