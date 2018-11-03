using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace CMcKinnon.BGG.Client.Extensions
{
    internal static class ObjectExtensions
    {
        internal static string ConvertToQueryString(this object option, Dictionary<string, string> replacements = null)
        {
            List<string> options = new List<string>();

            PropertyInfo[] properties = option.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(option, null);
                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    string val = value.ToString().Trim();
                    if (value is bool)
                    {
                        val = (bool)value ? "1" : "0";
                    }
                    if (value is DateTime dt)
                    {
                        val = dt.ToString("yyyy-MM-dd");
                    }
                    string queryValue = HttpUtility.UrlEncode(val);
                    string propName = property.Name.ToLower();
                    propName = replacements?.ContainsKey(propName) ?? false ? replacements[propName] : propName;
                    options.Add(string.Join("=", propName, queryValue));
                }
            }

            return string.Join("&", options);
        }
    }
}
