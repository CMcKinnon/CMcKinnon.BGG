namespace CMcKinnon.BGG.Client.Constants
{
    internal static class Endpoints
    {
        internal static readonly string BGG = "https://boardgamegeek.com";

        internal static readonly string BASE_URI = $"{BGG}/xmlapi";

        internal static readonly string SEARCH = $"{BASE_URI}/search";

        internal static readonly string GET_BOARDGAMES = $"{BASE_URI}/boardgame";

        internal static readonly string GET_COLLECTION = $"{BASE_URI}/collection";

        internal static readonly string GET_FORUM_THREAD = $"{BGG}/rss/thread";

        internal static readonly string GET_GEEKLIST = $"{BASE_URI}/geeklist";
    }
}
