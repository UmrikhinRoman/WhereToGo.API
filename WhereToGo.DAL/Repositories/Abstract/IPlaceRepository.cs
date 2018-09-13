using System;
using System.Collections.Generic;
using System.Text;
using WhereToGo.DAL.Domain;

namespace WhereToGo.DAL.Repositories.Abstract
{
    public interface IPlaceRepository: IRepository<Place>
    {
        IEnumerable<Place> GetPlacesByTagsIds(IEnumerable<string> tagsIds);
    }
}
