﻿using Npgsql;
using System.Collections.Generic;

namespace BrandManagerV1
{
    public class BrandRepository : IDataAccess
    {
        readonly string connectionString = "Server=localhost;Port=5432;Database=mydatabase;UserId=postgres;Password=L.a_#r_)asd;";

        public void CreateRecord(string brandName, bool isEnabled)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO brands (name, is_enabled) VALUES (@name, @is_enabled)";
                    command.Parameters.AddWithValue("@name", brandName);
                    command.Parameters.AddWithValue("@is_enabled", isEnabled);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public List<Brand> ReadRecords()
        {
            var brands = new List<Brand>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id, name, is_enabled FROM brands WHERE is_enabled = true";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string brandName = reader.GetString(1);
                            bool isEnabled = reader.GetBoolean(2);
                            brands.Add(new Brand { Id = id, Name = brandName, IsEnabled = isEnabled });
                        }
                    }
                }

                connection.Close();
            }

            return brands;
        }


        public void UpdateRecord(int id, string brandName, bool isEnabled)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE brands SET name = @name, is_enabled = @is_enabled WHERE id = @id";
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("@name", brandName);
                    command.Parameters.AddWithValue("@is_enabled", isEnabled);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void DeleteRecord(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM brands WHERE id = @id";
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void CreateTableIfNotExists(string tableName)
        {
            string connectionString = "Server=localhost;Port=5432;Database=mydatabase;UserId=postgres;Password=L.a_#r_)asd;";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"CREATE TABLE IF NOT EXISTS {tableName} (id smallserial PRIMARY KEY, name varchar(255) NOT NULL, is_enabled boolean NOT NULL)";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

        }
    }
}