using System;
using System.Collections.Generic;
using System.Text;
using WhereToGo.BL.Models;
using WhereToGo.BL.Models.Places;

namespace WhereToGo.BL.Services.Abstract
{
    public interface IPlaceService
    {
        void CreatePlace(PlaceModel place);
        void UpdatePlace(PlaceModel place);
        void DeletePlace(string id);
        void AddTagsToPlace(string placeId, IEnumerable<string> tagsIds);
        IEnumerable<PlaceModel> GetPlaces(IEnumerable<string> tagsIds);
    }
}
