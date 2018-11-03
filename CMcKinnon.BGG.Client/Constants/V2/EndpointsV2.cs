namespace CMcKinnon.BGG.Client.Constants.V2
{
    internal static class EndpointsV2
    {
        internal static readonly string BGG_BASE = "https://www.boardgamegeek.com/xmlapi2";
        internal static readonly string THING_URI = $"{BGG_BASE}/thing";
        internal static readonly string BOARDGAME_URI = $"{THING_URI}?";
        internal static readonly string SEARCH_URI = $"{BGG_BASE}/search";
        internal static readonly string HOT_ITEMS_URI = $"{BGG_BASE}/hot";
        internal static readonly string PLAYS_URI = $"{BGG_BASE}/plays";
    }
}
