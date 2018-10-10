using CMcKinnon.BGG.Client.Web;
using CMcKinnon.BGG.Contracts;
using CMcKinnon.BGG.Contracts.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client
{
    public class SearchClient : ISearchClient
    {
        private readonly IXmlRestClient xmlRestClient;

        public SearchClient(IXmlRestClient xmlRestClient)
        {
            this.xmlRestClient = xmlRestClient;
        }

        public async Task<IEnumerable<boardgames>> SearchAsync(string term, bool exact)
        {
            string uri = $"{Endpoints.SEARCH}?search={term}";
            if (exact)
            {
                uri = $"{uri}&exact=1";
            }
            var resp = await xmlRestClient.GetAsync(uri);



            return null;
        }
    }
}
