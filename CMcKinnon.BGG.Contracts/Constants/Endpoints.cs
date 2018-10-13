namespace CMcKinnon.BGG.Contracts.Constants
{
    public static class Endpoints
    {
        public static readonly string BASE_URI = "https://boardgamegeek.com/xmlapi";

        public static readonly string SEARCH = $"{BASE_URI}/search";

        public static readonly string GET_BOARDGAMES = $"{BASE_URI}/boardgame";
    }
}
