using System;
using System.Collections.Generic;
using System.Text;
using WhereToGo.BL.Models;
using WhereToGo.DAL.Domain;

namespace WhereToGo.BL.Services.Abstract
{
    public interface ITagService
    {
        IEnumerable<TagModel> GetTopKPopularTags(int count);
        
    }

}
