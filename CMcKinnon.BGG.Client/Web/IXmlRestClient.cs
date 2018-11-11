using CMcKinnon.BGG.Client.Contracts;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client.Web
{
    public interface IXmlRestClient
    {
        Task<HttpResponseMessage> GetAsync(string uri, Action<HttpRequestHeaders> setHeaders = null);
        Task<HttpResponseMessage> GetWithRetryAsync(string uri, RetrySettings retrySettings, Action<HttpRequestHeaders> setHeaders = null);
    }
}
