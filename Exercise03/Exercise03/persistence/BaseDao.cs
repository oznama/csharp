using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

/*
 * Dao = DAO = Data Access Object = Objeto de acceso a datos
 * Base = palabra reservada para hacer referencia a la clase padre
 * de una clase derivada
 * BaseDao = Clase padre para acceso a datos
 */

namespace Exercise03.persistence
{
    class BaseDao
    {
        private const string serverName = "DESKTOP-U5TLDJ6";
        private const string databaseName = "exercice03";
        private const string userId = "paula";
        private const string password = "1234";
        private const string cs = "Server="+serverName+";Database="+databaseName+";User Id="+userId+";Password="+password+";";

        protected string query;
        protected Dictionary<string, object> @params;

        public BaseDao()
        {
            @params = new Dictionary<string, object>();
        }

        protected ArrayList SelectQuery() {
            ArrayList list = new ArrayList();
            using(SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    foreach (KeyValuePair<string, object> p in @params)
                    {
                        command.Parameters.AddWithValue(p.Key, p.Value);
                    }
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    object[] columns;
                    while (reader.Read())
                    {
                        columns = new object[reader.FieldCount];
                        for(int i=0; i<reader.FieldCount; i++)
                        {
                            columns[i] = reader[i];
                        }
                        list.Add(columns);
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return list;
        }

        protected Boolean Execute()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        foreach(KeyValuePair<string,object> p in @params)
                        {
                            command.Parameters.AddWithValue(p.Key, p.Value);
                        }
                        connection.Open();
                        int rowsAfecteds = command.ExecuteNonQuery();
                        Console.WriteLine("Rows afecteds: {0}", rowsAfecteds);
                        return rowsAfecteds > 0 ? true : false;
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return false;
            }
        }
    }
}
