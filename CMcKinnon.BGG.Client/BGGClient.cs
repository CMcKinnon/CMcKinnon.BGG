using CMcKinnon.BGG.Client.Extensions;
using CMcKinnon.BGG.Client.Web;
using CMcKinnon.BGG.Client.XmlContracts;
using CMcKinnon.BGG.Contracts.Boardgames;
using CMcKinnon.BGG.Contracts.Collections;
using CMcKinnon.BGG.Contracts.Constants;
using CMcKinnon.BGG.Contracts.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CMcKinnon.BGG.Client
{
    public class BGGClient : IBGGClient
    {
        private readonly IXmlRestClient xmlRestClient;

        public BGGClient(IXmlRestClient xmlRestClient)
        {
            this.xmlRestClient = xmlRestClient;
        }

        public async Task<IList<BoardgameResult>> SearchAsync(string term, bool exact = false)
        {
            string uri = $"{Endpoints.SEARCH}?search={HttpUtility.UrlEncode(term)}";
            if (exact)
            {
                uri = $"{uri}&exact=1";
            }
            HttpResponseMessage resp = await xmlRestClient.GetAsync(uri);

            resp.EnsureSuccessStatusCode();

            _BoardgameSearchResult result = await resp.Content.DeserializeXml<_BoardgameSearchResult>();

            return result.ConvertToBoardgameResultList();
        }

        public async Task<IList<Boardgame>> GetBoardgamesAsync(int[] objectIds, bool includeComments = false, int commentPage = 1, bool includeStatistics = false)
        {
            string uri = $"{Endpoints.GET_BOARDGAMES}/{string.Join(",", objectIds)}";

            List<string> queryParams = new List<string>();
            if (includeComments)
            {
                queryParams.Add("comments=1");
                queryParams.Add($"page={commentPage}");
            }
            if (includeStatistics)
            {
                queryParams.Add("stats=1");
            }

            if (queryParams.Any())
            {
                uri = uri + $"?{string.Join("&", queryParams)}";
            }

            HttpResponseMessage resp = await xmlRestClient.GetAsync(uri);

            resp.EnsureSuccessStatusCode();

            _BoardgameSearchResult result = await resp.Content.DeserializeXml<_BoardgameSearchResult>();

            return result.ConvertToBoardgameList();
        }

        public async Task<CollectionHeader> GetUserCollection(string user, RetrySettings retrySettings)
        {
            string uri = $"{Endpoints.GET_COLLECTION}/{user}";

            HttpResponseMessage resp = null;
            bool done = false;
            int retry = 0;
            TimeSpan waitSeconds = TimeSpan.FromSeconds(Math.Max(retrySettings.WaitSeconds, 1));

            while (!done)
            {
                resp = await xmlRestClient.GetAsync(uri);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    done = true;
                }
                else if (resp.StatusCode == HttpStatusCode.Accepted)
                {
                    if (!retrySettings.Retry || retry >= retrySettings.RetryCount)
                    {
                        return new CollectionHeader { StatusCode = (int)HttpStatusCode.Accepted };
                    }
                    else
                    {
                        retry += 1;
                        Thread.Sleep(waitSeconds);
                    }
                }
            }

            _CollectionResult result = await resp.Content.DeserializeXml<_CollectionResult>();

            return result.ConvertToCollectionHeader();
        }
    }
}
