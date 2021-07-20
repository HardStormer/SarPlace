using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;

namespace GMD.SarPlace.DAL.Interfaces
{
    public interface ICommentsDAO
    {
        Comment Add(Comment comment);
        IEnumerable<Comment> GetAll();
        void Edit(Comment comment);
        void Remove(Guid id);
        Comment GetById(Guid id);
    }
}
