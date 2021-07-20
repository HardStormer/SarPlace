using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;

namespace GMD.SarPlace.DAL.Interfaces
{
    public interface IUsersDAO
    {
        User Add(User user);
        IEnumerable<User> GetAll();
        void Edit(User user);
        void Remove(Guid id);
        User GetById(Guid id);
        IEnumerable<Place> GetPlacesByUserId(Guid id);
        IEnumerable<Comment> GetCommentsByUserId(Guid id);

    }
}
