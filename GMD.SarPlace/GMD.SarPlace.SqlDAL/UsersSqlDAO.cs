using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;
using GMD.SarPlace.DAL.Interfaces;
using System.Data.SqlClient;
using System.Configuration;

namespace GMD.SarPlace.SqlDAL
{
    public class UsersSqlDAO : IUsersDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["SarPlace"].ConnectionString;
        public User Add(User user)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Users(User_id, RegistrationDate, Name, Password) " +
                    "VALUES(@User_id, @RegistrationDate, @Name, @Password)" +
                    "SELECT CAST(@User_id AS uniqueidentifier) AS NewID;";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@User_id", user.ID);
                command.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Password", user.Password);

                _connection.Open();
                var result = (Guid)command.ExecuteScalar();
                if (result != null)
                    return new User(
                        result,
                        user.RegistrationDate,
                        user.Name,
                        user.Password);

                throw new InvalidOperationException(
                string.Format("Cannot add User with parameters: {0}, {1}, {2}, {3};",
                user.ID, user.RegistrationDate, user.Name, user.Password));
            }
        }

        public void Edit(User user)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Users SET " +
                "Name = @Name, Password = @Password " +
                "WHERE User_id = @User_id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@User_id", user.ID);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Password", user.Password);

                _connection.Open();

                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = new List<User>();
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT User_id, RegistrationDate, Name, Password FROM Users";

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User(
                            id: (Guid)reader["User_id"],
                            datetime: (DateTime)reader["RegistrationDate"],
                            name: reader["Name"] as string,
                            password: reader["Password"] as string
                            ));
                }

            }
            return users;
        }

        public User GetById(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT User_id, RegistrationDate, Name, Password " +
                    "FROM Users WHERE User_id = @User_id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@User_id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User(
                        id: (Guid)reader["User_id"],
                        datetime: (DateTime)reader["RegistrationDate"],
                        name: reader["Name"] as string,
                        password: reader["Password"] as string
                        );
                }

                throw new InvalidOperationException("Cannot find User with ID = " + id);
            }
        }

        public IEnumerable<Comment> GetCommentsByUserId(Guid id)
        {
            List<Comment> comments = new List<Comment>();
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Comment_id, PublicationDate, Place_id, User_id, Text " +
                    "FROM Comments " +
                    "WHERE User_id = @UserID";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@UserID", id);

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

        public IEnumerable<Place> GetPlacesByUserId(Guid id)
        {
            List<Place> places = new List<Place>();
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Place_id, PublicationDate, User_id, Title, Text " +
                    "FROM Places " +
                    "WHERE User_id = @UserID";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@UserID", id);
                

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
    

        public void Remove(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Comments WHERE User_id = @User_id " +
                    "DELETE FROM Places WHERE User_id = @User_id " +
                    "DELETE FROM Users WHERE User_id = @User_id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@User_id", id);

                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw new InvalidOperationException("Cannot find User with ID = " + id);
                }
            }
        }
    }
}
