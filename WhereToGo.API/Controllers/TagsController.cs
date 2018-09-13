using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using WhereToGo.BL.Models;
using WhereToGo.BL.Services.Abstract;
using WhereToGo.DAL.Domain;

namespace WhereToGo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet("top")]
        public IEnumerable<TagModel> GetTopKTags([FromQuery] int count = 10)
        {
            return _tagService.GetTopKPopularTags(count);
        }

        // GET: api/Tags
        [HttpGet("")]
        public string GetTags()
        {
            return "Tags list";
        }
    }
}