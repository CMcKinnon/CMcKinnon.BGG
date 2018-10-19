using System;

namespace CMcKinnon.BGG.Contracts.Collections
{
    public class CollectionItemStatus
    {
        public bool Own { get; set; }
        public bool PreviouslyOwned { get; set; }
        public bool ForTrade { get; set; }
        public bool Want { get; set; }
        public bool WantToPlay { get; set; }
        public bool WantToBuy { get; set; }
        public bool Wishlist { get; set; }
        public int WishlistPriority { get; set; }
        public bool Preordered { get; set; }
        public DateTime LastModified { get; set; }
    }
}
