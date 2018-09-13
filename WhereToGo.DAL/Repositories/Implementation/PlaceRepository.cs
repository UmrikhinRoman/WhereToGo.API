using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WhereToGo.DAL.Domain;
using WhereToGo.DAL.Repositories.Abstract;

namespace WhereToGo.DAL.Repositories.Implementation
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlacesContext PlacesContext => Context as PlacesContext;

        public PlaceRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Place> GetPlacesByTagsIds(IEnumerable<string> tagsIds)
        {
            return Context.Set<Place>()
                .Include(p => p.PlaceTags)
                .Where(p => tagsIds
                    .All(t => p.PlaceTags
                        .Select(pt => pt.TagId)
                        .Contains(t)))
                .ToList();
        }
    }
}