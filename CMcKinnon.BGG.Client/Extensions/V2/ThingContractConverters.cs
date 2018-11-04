using CMcKinnon.BGG.Client.XmlContracts.V2;
using CMcKinnon.BGG.Contracts.V2;
using System.Net;

namespace CMcKinnon.BGG.Client.Extensions.V2
{
    public static class ThingContractConverters
    {
        public static ThingResult ConvertToThingResult(this _ThingResult thing)
        {
            return new ThingResult
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
