namespace CMcKinnon.BGG.Contracts.Collections
{
    public class CollectionQueryOption
    {
        public bool? Own { get; set; } = null;
        public bool? Rated { get; set; } = null;
        public bool? Played { get; set; } = null;
        public bool? Comment { get; set; } = null;
        public bool? Trade { get; set; } = null;
        public bool? Want { get; set; } = null;
        public bool? WantInTrade { get; set; } = null;
        public bool? Wishlist { get; set; } = null;
        public bool? WantToPlay { get; set; } = null;
        public bool? WantToBuy { get; set; } = null;
        public bool? PrevOwned { get; set; } = null;
        public bool? Preordered { get; set; } = null;
        public bool? HasParts { get; set; } = null;
        public bool? WantParts { get; set; } = null;
        public bool? NotifyContent { get; set; } = null;
        public bool? NotifySale { get; set; } = null;
        public bool? NotifyAuction { get; set; } = null;
        public int? WishlistPriority { get; set; } = null;
        public int? MinRating { get; set; } = null;
        public int? MaxRating { get; set; } = null;
        public int? MinBGGRating { get; set; } = null;
        public int? MaxBGGRating { get; set; } = null;
        public int? MinPlays { get; set; } = null;
        public int? MaxPlays { get; set; } = null;
    }
}
