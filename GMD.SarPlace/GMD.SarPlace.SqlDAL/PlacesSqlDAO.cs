using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;
using GMD.SarPlace.DAL.Interfaces;
using System.Data.SqlClient;
using System.Configuration;

namespace GMD.SarPlace.SqlDAL
{
    public class PlacesSqlDAO : IPlacesDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["SarPlace"].ConnectionString;
        public Place Add(Place place)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Places(Place_id, PublicationDate, User_id, Title, Text) " +
                    "VALUES(@Place_id, @PublicationDate, @User_id, @Title, @Text)" +
                    "SELECT CAST(@Place_id AS uniqueidentifier) AS NewID;";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Place_id", place.ID);
                command.Parameters.AddWithValue("@PublicationDate", place.PublicationDate);
                command.Parameters.AddWithValue("@User_id", place.User_id);
                command.Parameters.AddWithValue("@Title", place.Title);
                command.Parameters.AddWithValue("@Text", place.Text);

                _connection.Open();
                var result = (Guid)command.ExecuteScalar();
                if (result != null)
                    return new Place(
                        result,
                        place.PublicationDate,
                        place.User_id,
                        place.Title,
                        place.Text);

                throw new InvalidOperationException(
                string.Format("Cannot add User with parameters: {0}, {1}, {2}, {3}, {4};",
                place.ID, place.PublicationDate, place.User_id, place.Title, place.Text));
            }
        }

        public void Edit(Place place)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Places SET Title = @Title, " +
                "Text = @Text " +
                "WHERE Place_id = @Place_id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Place_id", place.ID);
                command.Parameters.AddWithValue("@Title", place.Title);
                command.Parameters.AddWithValue("@Text", place.Text);

                _connection.Open();

                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<Place> GetAll()
        {
            List<Place> places = new List<Place>();
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Place_id, PublicationDate, User_id, Title, Text FROM Places";

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    places.Add(new Place(
                            id: (Guid)reader["Place_id"],
                            publicationDate: (DateTime)reader["PublicationDate"],
                            user_id: (Guid)reader["User_id"],
                            title: reader["Title"] as string,
                            text: reader["Text"] as string
                            ));
                }

            }
            return places;
        }

        public Place GetById(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Place_id, PublicationDate, User_id, Title, Text " +
                    "FROM Places WHERE Place_id = @Place_id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Place_id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Place(
                            id: (Guid)reader["Place_id"],
                            publicationDate: (DateTime)reader["PublicationDate"],
                            user_id: (Guid)reader["User_id"],
                            title: reader["Title"] as string,
                            text: reader["Text"] as string
                            );
                }

                throw new InvalidOperationException("Cannot find Place with ID = " + id);
            }
        }

        public IEnumerable<Comment> GetCommentsByPlaceId(Guid id)
        {
            List<Comment> comments = new List<Comment>();
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Comment_id, PublicationDate, Place_id, User_id, Text " +
                    "FROM " +
                    "Comments WHERE Place_id = @PlaceID";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@PlaceID", id);

                _connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read()) 
                { 
                    comments.Add(new Comment(
                    id: (Guid)reader["Comment_id"], 
                    publicationDate: (DateTime)reader["PublicationDate"], 
                    place_id: (Guid)reader["Place_id"], 
                    user_id: (Guid)reader["User_id"], 
                    text: reader["Text"] as string
                    )); 
                }

            }
            return comments;
        }

        public void Remove(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Comments WHERE Place_id = @Place_id " +
                    "DELETE FROM Places WHERE Place_id = @Place_id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Place_id", id);

                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw new InvalidOperationException("Cannot find Place with ID = " + id);
                }
            }
        }
    }
}
