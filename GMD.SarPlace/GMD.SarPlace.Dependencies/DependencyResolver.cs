using GMD.SarPlace.StandartBLL;
using GMD.SarPlace.BLL.Interfaces;
using GMD.SarPlace.DAL.Interfaces;
using GMD.SarPlace.SqlDAL;

namespace GMD.SarPlace.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETONE

        private static DependencyResolver _instance = null;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DependencyResolver();

                return _instance;
            }
        }

        #endregion

        public IUsersDAO usersDAO => new UsersSqlDAO();
        public IPlacesDAO placesDAO => new PlacesSqlDAO();
        public ICommentsDAO commentsDAO => new CommentsSqlDAO();

        public IUsersLogic usersLogic => new UsersLogic(usersDAO);
        public IPlacesLogic placesLogic => new PlacesLogic(placesDAO);
        public ICommentsLogic commentsLogic => new CommentsLogic(commentsDAO);
    }
}
