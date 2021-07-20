using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;

namespace GMD.SarPlace.BLL.Interfaces
{
    public interface ICommentsLogic
    {
        Comment Add(Comment comment);
        IEnumerable<Comment> GetAll();
        void Edit(Comment comment);
        void Remove(Guid id);
        Comment GetById(Guid id);
    }
}
