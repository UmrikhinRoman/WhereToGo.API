using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using WhereToGo.BL.Models;
using WhereToGo.BL.Models.Places;
using WhereToGo.BL.Services.Abstract;
using WhereToGo.DAL.Domain;
using WhereToGo.DAL.Repositories.Abstract;

namespace WhereToGo.BL.Services.Implementation
{
    public class PlaceService: IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;

        public PlaceService(IPlaceRepository placeRepository, IMapper mapper)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
        }

        public void CreatePlace(PlaceModel place)
        {
            _placeRepository.Add(_mapper.Map<Place>(place));
        }

        public void UpdatePlace(PlaceModel place)
        {
            _placeRepository.Update(_mapper.Map<Place>(place));
        }

        public void DeletePlace(string id)
        {
            _placeRepository.Remove(id);
        }

        public void AddTagsToPlace(string placeId, IEnumerable<string> tagsIds)
        {
            var placeModel = _placeRepository.Find(p => p.Id == placeId).First();
            placeModel.PlaceTags = new List<PlaceTag>();
            foreach (var tagId in tagsIds)
            {
                placeModel.PlaceTags.Add(new PlaceTag() {  PlaceId = placeId, TagId = tagId });
            }
            _placeRepository.Update(placeModel);
        }

        public IEnumerable<PlaceModel> GetPlaces(IEnumerable<string> tagsIds)
        {
            if (!tagsIds.Any())
            {
                return _mapper.Map<List<PlaceModel>>(_placeRepository.GetAll());
            }
            var places = _placeRepository.GetPlacesByTagsIds(tagsIds);
            return _mapper.Map<List<PlaceModel>>(places);
        }
    }
}
