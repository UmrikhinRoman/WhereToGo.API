using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WhereToGo.BL.Models;
using WhereToGo.BL.Services.Abstract;
using WhereToGo.DAL.Domain;
using WhereToGo.DAL.Repositories.Abstract;


namespace WhereToGo.BL.Services.Implementation
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagrepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagrepository, IMapper mapper)
        {
            _tagrepository = tagrepository;
            _mapper = mapper;
        }

        public IEnumerable<TagModel> GetTopKPopularTags(int count)
        {
            var model = _tagrepository.GetTopKPopularTags(count);
            return _mapper.Map<List<TagModel>>(model);
        }
    }
}
