using System.Collections.Generic;
using WhereToGo.DAL.Base;

namespace WhereToGo.DAL.Domain
{
    public class Tag: BaseEntity
    {
        public string Name  { get; set; }
        public ICollection<PlaceTag> PlaceTags { get; set; }
    }
}
