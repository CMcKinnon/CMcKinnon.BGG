﻿using CMcKinnon.BGG.Client.Contracts;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace CMcKinnon.BGG.Client.Web
{
    public class XmlRestClient : IXmlRestClient
    {
        private readonly HttpClient httpClient;

        public const string CONTENT_TYPE_XML = "application/xml";

        public XmlRestClient()
        {
            httpClient = CreateHttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string uri, Action<HttpRequestHeaders> setHeaders = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            setHeaders?.Invoke(request.Headers);

            HttpResponseMessage response = await InvokeRequestAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> GetWithRetryAsync(string uri, RetrySettings retrySettings, Action<HttpRequestHeaders> setHeaders = null)
        {
            HttpResponseMessage resp = null;
            bool done = false;
            int retry = 0;
            TimeSpan waitSeconds = TimeSpan.FromSeconds(Math.Max(retrySettings.WaitSeconds, 1));

            while (!done)
            {
                resp = await GetAsync(uri);
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    done = true;
                }
                else if (resp.StatusCode == HttpStatusCode.Accepted)
                {
                    if (!retrySettings.Retry || retry >= retrySettings.RetryCount)
                    {
                        done = true;
                    }
                    else
                    {
                        retry += 1;
                        Thread.Sleep(waitSeconds);
                    }
                }
            }

            return resp;
        }

        private async Task<HttpResponseMessage> InvokeRequestAsync(HttpRequestMessage request)
        {
            if (request.Content != null)
            {
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(CONTENT_TYPE_XML);
            }

            return await httpClient.SendAsync(request).ConfigureAwait(false);
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(CONTENT_TYPE_XML));
            httpClient.Timeout = TimeSpan.FromMinutes(1);
            httpClient.MaxResponseContentBufferSize = 104857600; // 100mb

            return httpClient;
        }
    }
}
