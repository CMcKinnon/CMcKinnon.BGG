using CMcKinnon.BGG.Client.Extensions;
using CMcKinnon.BGG.Client.Web;
using CMcKinnon.BGG.Contracts.Constants;
using CMcKinnon.BGG.Contracts.Search;
using CMcKinnon.BGG.XmlContracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CMcKinnon.BGG.Client
{
    public class SearchClient : ISearchClient
    {
        private readonly IXmlRestClient xmlRestClient;

        public SearchClient(IXmlRestClient xmlRestClient)
        {
            this.xmlRestClient = xmlRestClient;
        }

        public async Task<IList<Boardgame>> SearchAsync(string term, bool exact)
        {
            string uri = $"{Endpoints.SEARCH}?search={HttpUtility.UrlEncode(term)}";
            if (exact)
            {
                uri = $"{uri}&exact=1";
            }
            HttpResponseMessage resp = await xmlRestClient.GetAsync(uri);

            resp.EnsureSuccessStatusCode();

            BoardgameSearchResult result = await resp.Content.DeserializeXml<BoardgameSearchResult>();

            return result.ConvertToBoardgameList();
        }
    }
}
