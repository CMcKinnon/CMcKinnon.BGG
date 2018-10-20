using CMcKinnon.BGG.Contracts.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace CMcKinnon.BGG.Client.Extensions
{
    internal static class CollectionQueryOptionExtensions
    {
        internal static string ConvertToQueryString(this CollectionQueryOption option)
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
                    string queryValue = HttpUtility.UrlEncode(val);
                    options.Add(string.Join("=", property.Name.ToLower(), queryValue));
                }
            }

            return string.Join("&", options);
        }
    }
}
