using WhereToGo.DAL.Base;

namespace WhereToGo.DAL.Domain
{
    public class Photo: BaseEntity
    {
        public string Name  { get; set; }
        public string Path { get; set; }

        public Place Place { get; set; }
        public string PlaceId { get; set; }
    }
}
