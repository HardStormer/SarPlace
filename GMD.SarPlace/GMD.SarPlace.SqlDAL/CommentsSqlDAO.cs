using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;
using GMD.SarPlace.DAL.Interfaces;
using System.Data.SqlClient;
using System.Configuration;

namespace GMD.SarPlace.SqlDAL
{
    public class CommentsSqlDAO : ICommentsDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["SarPlace"].ConnectionString;
        public Comment Add(Comment comment)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Comments(Comment_id, PublicationDate, Place_id, User_id, Text) " +
                    "VALUES(@Comment_id, @PublicationDate, @Place_id, @User_id, @Text)" +
                    "SELECT CAST(@Comment_id AS uniqueidentifier) AS NewID;";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Comment_id", comment.ID);
                command.Parameters.AddWithValue("@PublicationDate", comment.PublicationDate);
                command.Parameters.AddWithValue("@Place_id", comment.Place_id);
                command.Parameters.AddWithValue("@User_id", comment.User_id);
                command.Parameters.AddWithValue("@Text", comment.Text);

                _connection.Open();
                var result = (Guid)command.ExecuteScalar();
                if (result != null)
                    return new Comment(
                        result,
                        comment.PublicationDate,
                        comment.Place_id,
                        comment.User_id,
                        comment.Text);

                throw new InvalidOperationException(
                string.Format("Cannot add User with parameters: {0}, {1}, {2}, {3}, {4};",
                comment.ID, comment.PublicationDate, comment.Place_id, comment.User_id, comment.Text));
            }
        }

        public void Edit(Comment comment)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Comments SET Text = @Text " +
                "WHERE Comment_id = @Comment_id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Comment_id", comment.ID);
                command.Parameters.AddWithValue("@Text", comment.Text);

                _connection.Open();

                command.ExecuteNonQuery();

            }
        }

        public IEnumerable<Comment> GetAll()
        {
            List<Comment> comments = new List<Comment>();
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Comment_id, PublicationDate, Place_id, User_id, Text FROM Comments";

                var command = new SqlCommand(query, _connection);

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

        public Comment GetById(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Comment_id, PublicationDate, Place_id, User_id, Text " +
                    "FROM Comments WHERE Comment_id = @Comment_id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Comment_id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Comment(
                            id: (Guid)reader["Comment_id"],
                            publicationDate: (DateTime)reader["PublicationDate"],
                            place_id: (Guid)reader["Place_id"],
                            user_id: (Guid)reader["User_id"],
                            text: reader["Text"] as string
                            );
                }

                throw new InvalidOperationException("Cannot find Comment with ID = " + id);
            }
        }

        public void Remove(Guid id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Comments WHERE Comment_id = @Comment_id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Comment_id", id);

                try
                {
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw new InvalidOperationException("Cannot find Comment with ID = " + id);
                }
            }
        }
    }
}
