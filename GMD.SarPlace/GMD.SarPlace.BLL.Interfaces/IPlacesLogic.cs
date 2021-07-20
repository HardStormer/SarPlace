using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;

namespace GMD.SarPlace.BLL.Interfaces
{
    public interface IPlacesLogic
    {
        Place Add(Place place);
        IEnumerable<Place> GetAll();
        void Edit(Place place);
        void Remove(Guid id);
        Place GetById(Guid id);
        IEnumerable<Comment> GetCommentsByPlaceId(Guid id);
    }
}
