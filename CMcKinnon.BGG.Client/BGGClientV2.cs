using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CMcKinnon.BGG.Client.Constants.V2;
using CMcKinnon.BGG.Client.Extensions;
using CMcKinnon.BGG.Client.Extensions.V2;
using CMcKinnon.BGG.Client.Web;
using CMcKinnon.BGG.Client.XmlContracts.V2;
using CMcKinnon.BGG.Contracts.V2;

namespace CMcKinnon.BGG.Client
{
    public class BGGClientV2 : IBGGClientV2
    {
        private readonly IXmlRestClient xmlRestClient;

        public BGGClientV2(IXmlRestClient xmlRestClient)
        {
            this.xmlRestClient = xmlRestClient;
        }

        public async Task<SearchResult> SearchAsync(string query, ThingType? type = null, bool exact = false)
        {
            string uri = $"{EndpointsV2.SEARCH_URI}?query={query}";
            if (type.HasValue)
            {
                uri += $"&type={type}";
            }
            if (exact)
            {
                uri += "&exact=1";
            }

            HttpResponseMessage resp = await xmlRestClient.GetAsync(uri);

            if (!resp.IsSuccessStatusCode)
            {
                return new SearchResult { StatusCode = (int)resp.StatusCode };
            }

            _ItemsResult result = await resp.Content.DeserializeXml<_ItemsResult>();

            return result.ConvertToSearchResult();
        }

        public async Task<HotItemResult> GetHotItemsAsync(HotItemType type)
        {
            string uri = $"{EndpointsV2.HOT_ITEMS_URI}?type={type}";

            HttpResponseMessage resp = await xmlRestClient.GetAsync(uri);

            if (!resp.IsSuccessStatusCode)
            {
                return new HotItemResult { StatusCode = (int)resp.StatusCode };
            }

            _ItemsResult result = await resp.Content.DeserializeXml<_ItemsResult>();

            return result.ConvertToHotItemResult();
        }
    }
}
