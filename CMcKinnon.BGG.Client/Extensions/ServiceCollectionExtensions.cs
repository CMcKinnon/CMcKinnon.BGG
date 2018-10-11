using CMcKinnon.BGG.Client;
using CMcKinnon.BGG.Client.Web;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBGGClient(this IServiceCollection services)
        {
            services.AddSingleton<IXmlRestClient, XmlRestClient>();
            return services.AddSingleton<ISearchClient, SearchClient>();
        }
    }
}
