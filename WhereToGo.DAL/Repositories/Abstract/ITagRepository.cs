using System.Collections.Generic;
using WhereToGo.DAL.Domain;

namespace WhereToGo.DAL.Repositories.Abstract
{
    public interface ITagRepository: IRepository<Tag>
    {
        IEnumerable<Tag> GetTopKPopularTags(int count);
    }
}
