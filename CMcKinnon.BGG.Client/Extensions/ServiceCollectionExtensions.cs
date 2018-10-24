using CMcKinnon.BGG.Client;
using CMcKinnon.BGG.Client.Web;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBGGClient(this IServiceCollection services)
        {
            services.AddSingleton<IXmlRestClient, XmlRestClient>();
            services.AddSingleton<IBGGClient, BGGClient>();
            services.AddSingleton<IBGGClientV2, BGGClientV2>();

            return services;
        }
    }
}
