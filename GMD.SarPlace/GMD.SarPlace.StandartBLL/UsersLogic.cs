using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;
using GMD.SarPlace.BLL.Interfaces;
using GMD.SarPlace.DAL.Interfaces;

namespace GMD.SarPlace.StandartBLL
{
    public class UsersLogic : IUsersLogic
    {
        private readonly IUsersDAO _userDAO;
        public UsersLogic(IUsersDAO usersDAO)
        {
            _userDAO = usersDAO;
        }
        public User Add(User user)
        {
            return _userDAO.Add(user);
        }

        public void Edit(User user)
        {
            _userDAO.Edit(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDAO.GetAll();
        }

        public User GetById(Guid id)
        {
            return _userDAO.GetById(id);
        }

        public IEnumerable<Comment> GetCommentsByUserId(Guid id)
        {
            return _userDAO.GetCommentsByUserId(id);
        }

        public IEnumerable<Place> GetPlacesByUserId(Guid id)
        {
            return _userDAO.GetPlacesByUserId(id);
        }

        public void Remove(Guid id)
        {
            _userDAO.Remove(id);
        }
    }
}
