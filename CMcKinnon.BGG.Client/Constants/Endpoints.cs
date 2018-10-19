namespace CMcKinnon.BGG.Client.Constants
{
    internal static class Endpoints
    {
        internal static readonly string BASE_URI = "https://boardgamegeek.com/xmlapi";

        internal static readonly string SEARCH = $"{BASE_URI}/search";

        internal static readonly string GET_BOARDGAMES = $"{BASE_URI}/boardgame";

        internal static readonly string GET_COLLECTION = $"{BASE_URI}/collection";
    }
}
