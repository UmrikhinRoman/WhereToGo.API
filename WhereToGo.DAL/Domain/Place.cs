using System.Collections.Generic;
using WhereToGo.DAL.Base;

namespace WhereToGo.DAL.Domain
{
    public class Place: BaseEntity
    {
        public string Name { get; set; }
        public string PlaceImage { get; set; }
        public string Description { get; set; }
        public string Site { get; set; }
        public string Phone { get; set; }
        public bool IsConfirmed { get; set; }
        public int ConfirmationsCount { get; set; }
        public int Rating { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<PlaceTag> PlaceTags { get; set; }
    }
}