using CMcKinnon.BGG.Client.Web;
using CMcKinnon.BGG.Contracts;
using CMcKinnon.BGG.Contracts.Constants;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMcKinnon.BGG.Client
{
    public class SearchClient : ISearchClient
    {
        private readonly IXmlRestClient xmlRestClient;

        public SearchClient(IXmlRestClient xmlRestClient)
        {
            this.xmlRestClient = xmlRestClient;
        }

        public async Task<boardgames> SearchAsync(string term, bool exact)
        {
            string uri = $"{Endpoints.SEARCH}?search={term}";
            if (exact)
            {
                uri = $"{uri}&exact=1";
            }
            HttpResponseMessage resp = await xmlRestClient.GetAsync(uri);

            resp.EnsureSuccessStatusCode();

            byte[] contentBytes = await resp.Content.ReadAsByteArrayAsync();
            string xml = Encoding.UTF8.GetString(contentBytes);

            boardgames result;
            using(TextReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(boardgames));
                result = (boardgames)serializer.Deserialize(reader);

            }

            return result;
        }
    }
}
