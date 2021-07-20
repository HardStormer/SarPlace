using GMD.SarPlace.Etities;
using System;
using System.Collections.Generic;

namespace GMD.SarPlace.DAL.Interfaces
{
    public interface IPlacesDAO
    {
        Place Add(Place place);
        IEnumerable<Place> GetAll();
        void Edit(Place place);
        void Remove(Guid id);
        Place GetById(Guid id);
        IEnumerable<Comment> GetCommentsByPlaceId(Guid id);
    }
}
