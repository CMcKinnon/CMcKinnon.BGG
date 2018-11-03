using CMcKinnon.BGG.Client.Constants.V2;
using CMcKinnon.BGG.Client.Extensions;
using CMcKinnon.BGG.Client.Extensions.V2;
using CMcKinnon.BGG.Client.Web;
using CMcKinnon.BGG.Client.XmlContracts.V2;
using CMcKinnon.BGG.Contracts.V2;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client
{
    public class BGGClientV2 : IBGGClientV2
    {
        private readonly IXmlRestClient xmlRestClient;
        private readonly Dictionary<string, string> playParamConversion = new Dictionary<string, string>
        {
            { "objectid", "id" },
            { "playtype", "type" },
            { "playsubtype", "subtype" }
        };

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

        public async Task<PlayResult> GetPlaysAsync(PlayRequest request)
        {
            string uri = EndpointsV2.PLAYS_URI;

            string queryString = request.ConvertToQueryString(playParamConversion);
            if (!string.IsNullOrEmpty(queryString))
            {
                uri = $"{uri}?{queryString}";
            }

            HttpResponseMessage resp = await xmlRestClient.GetAsync(uri);

            if (!resp.IsSuccessStatusCode)
            {
                return new PlayResult { StatusCode = (int)resp.StatusCode };
            }

            _PlayResult result = await resp.Content.DeserializeXml<_PlayResult>();

            return result.ConvertToPlayResult();
        }
    }
}
