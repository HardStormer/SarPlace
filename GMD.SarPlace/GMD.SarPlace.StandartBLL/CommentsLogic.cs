using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;
using GMD.SarPlace.BLL.Interfaces;
using GMD.SarPlace.DAL.Interfaces;

namespace GMD.SarPlace.StandartBLL
{
    public class CommentsLogic : ICommentsLogic
    {
        private readonly ICommentsDAO _commentDAO;
        public CommentsLogic(ICommentsDAO commentsDAO)
        {
            _commentDAO = commentsDAO;
        }
        public Comment Add(Comment comment)
        {
            return _commentDAO.Add(comment);
        }

        public void Edit(Comment comment)
        {
            _commentDAO.Edit(comment);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _commentDAO.GetAll();
        }

        public Comment GetById(Guid id)
        {
            return _commentDAO.GetById(id);
        }

        public void Remove(Guid id)
        {
            _commentDAO.Remove(id);
        }
    }
}
