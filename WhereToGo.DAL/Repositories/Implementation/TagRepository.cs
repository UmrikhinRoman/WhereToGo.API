using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhereToGo.DAL.Domain;
using WhereToGo.DAL.Repositories.Abstract;

namespace WhereToGo.DAL.Repositories.Implementation
{
    public class TagRepository: Repository<Tag>, ITagRepository
    {

        public PlacesContext PlacesContext => Context as PlacesContext;

        public TagRepository(DbContext context) : base(context)
        {
        }  

        public IEnumerable<Tag> GetTopKPopularTags(int count)
        {
            return PlacesContext.Set<Tag>()
                .Include(t => t.PlaceTags)
                .OrderBy(t => t.PlaceTags.Count)
                .Take(count);
        }
    }
}
