using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Exercise03.model;

namespace Exercise03.persistence
{
    class ClientsDao : BaseDao, IClientsDao
    {
        public bool Delete(int id)
        {
            query = "DELETE FROM clients WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            return base.Execute();
        }

        public ArrayList FindAll(int id)
        {
            query = "SELECT id,name,address,phone,user_id,created_date FROM clients";
            ArrayList clients = new ArrayList();
            ArrayList result = base.SelectQuery();
            Clients client;
            foreach (object[] r in result)
            {
                client = new Clients
                {
                    ID = (int)r[0],
                    Name = (string)r[1],
                    Address = (string)r[2],
                    Phone = (string)r[3],
                    UserId = (int)r[4],
                    CreatedDate = (DateTime)r[5]
                };
                clients.Add(client);
            }
            return clients;
        }

        public Clients FindById(int id)
        {
            query = "SELECT id,name,address,phone,user_id,created_date FROM clients WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            try
            {
                object[] result =(object[])base.SelectQuery()[0];
                Clients client = new Clients
                {
                    ID = (int)result[0],
                    Name = (string)result[1],
                    Address = (string)result[2],
                    Phone = (string)result[3],
                    UserId = (int)result[4],
                    CreatedDate = (DateTime)result[5]
                };
                return client;

            }catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Cliente con ID: {0} no encontrado", id);
            }
            return null;
        }

        public ArrayList FindByUser(int userId)
        {
            query = "SELECT id, name, address, phone, created_date FROM clients WHERE user_id = @userId";
            @params = new Dictionary<string, object>
            {
                {"@userId",userId}
            };
            ArrayList clients = new ArrayList();
            ArrayList result = base.SelectQuery();
            Clients client;
            foreach (object[] r in result)
            {
                client = new Clients
                {
                    ID = (int)r[0],
                    Name = (string)r[1],
                    Address = (string)r[2],
                    Phone = (string)r[3],
                    CreatedDate = (DateTime)r[4]
                };
                clients.Add(client);
            }
            return clients;
        }

        public bool Save(Clients clients)
        {
            query = "INSERT INTO clients (name,address,phone,user_id,created_date) VALUES(@name,@address,@phone,@userId,@createdDate)";
            @params = new Dictionary<string, object>
            {
                { "@name",clients.Name },
                { "@address",clients.Address },
                { "@phone",clients.Phone },
                { "@userId",clients.UserId },
                { "@createdDate",clients.CreatedDate}
            };
            return base.Execute();
        }

        public bool Update(Clients clients)
        {
            query = "UPDATE clients SET name=@name,address=@address,phone=@phone,user_id=@userId,created_date=@createdDate WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@name", clients.Name},
                {"@address", clients.Address},
                {"@phone",clients.Phone},
                {"@userId",clients.UserId},
                {"@createdDate",clients.CreatedDate}
            };
            return base.Execute();
        }
    }
}
