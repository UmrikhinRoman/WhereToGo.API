namespace WhereToGo.DAL.Domain
{
    public class PlaceTag
    {
        public string TagId { get; set; }
        public Tag Tag { get; set; }

        public string PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
