using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereToGo.BL.Models;
using WhereToGo.BL.Models.Places;
using WhereToGo.BL.Services.Abstract;

namespace WhereToGo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Places")]
    public class PlacesController : ControllerBase
    {
        private const int PlaceTagsLimit = 10;

        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        // GET: api/Places
        [HttpGet]
        public IEnumerable<PlaceModel> Get(List<string> tagsIds)
        {
            return _placeService.GetPlaces(tagsIds);
        }

        // GET: api/Places/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return $"value {id}";
        }
        
        // POST: api/Places
        [HttpPost]
        public void Post([FromBody]PlaceModel place)
        {
            if (ModelState.IsValid)
            {
                _placeService.CreatePlace(place);
            }
            else
            {
                throw new HttpRequestException();
            }
        }
        
        // PUT: api/Places/5
        [HttpPut("{id}")]
        public void Put([FromBody] PlaceModel place)
        {
            if (ModelState.IsValid)
            {
                _placeService.UpdatePlace(place);
            }
            else
            {
                throw new HttpRequestException();
            }
        }
        
        // DELETE: api/Delete/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _placeService.DeletePlace(id);
        }

        [HttpPost("tag")]
        public void AddTags([FromQuery] string placeId, [FromBody] List<string> tagsIds)
        {
            if (tagsIds.Count() <= PlaceTagsLimit)
            {
                _placeService.AddTagsToPlace(placeId, tagsIds);
            }
            else
            {
                throw new InvalidDataException("Can't add more than 10 tags");
            }
        }
    }
}
