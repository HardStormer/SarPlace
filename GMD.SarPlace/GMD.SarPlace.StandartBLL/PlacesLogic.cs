using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;
using GMD.SarPlace.BLL.Interfaces;
using GMD.SarPlace.DAL.Interfaces;

namespace GMD.SarPlace.StandartBLL
{
    public class PlacesLogic : IPlacesLogic
    {
        private readonly IPlacesDAO _placeDAO;
        public PlacesLogic(IPlacesDAO placesDAO)
        {
            _placeDAO = placesDAO;
        }
        public Place Add(Place place)
        {
            return _placeDAO.Add(place);
        }

        public void Edit(Place place)
        {
            _placeDAO.Edit(place);
        }

        public IEnumerable<Place> GetAll()
        {
            return _placeDAO.GetAll();
        }

        public Place GetById(Guid id)
        {
            return _placeDAO.GetById(id);
        }

        public IEnumerable<Comment> GetCommentsByPlaceId(Guid id)
        {
            return _placeDAO.GetCommentsByPlaceId(id);
        }

        public void Remove(Guid id)
        {
            _placeDAO.Remove(id);
        }
    }
}
