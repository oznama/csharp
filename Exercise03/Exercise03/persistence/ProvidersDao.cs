using System;
using System.Collections;
using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    class ProvidersDao : BaseDao, IProvidersDao
    {
        public bool Delete(int id)
        {
            query = "DELETE FROM providers WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            return base.Execute();
        }

        public IList<Providers>FindAll()
        {
            query = "SELECT id,name,description,created_date,user_id FROM providers";
            @params.Clear();

            ArrayList result = base.SelectQuery();
            IList<Providers> providers = new List<Providers>();
            Providers provider;

            foreach (object[] r in result)
            {
                provider = new Providers
                {
                    Id = (int)r[0],
                    Name = (string)r[1],
                    Description = (string)r[2],
                    CreatedDate = (DateTime)r[3],
                    UserId = (int)r[4]
                };
                providers.Add(provider);
            }
            return providers;

        }

        public Providers FindById(int id)
        {
            query = "SELECT id,name,description,created_date,user_id FROM providers WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            try
            {
                object[] result = (object[])base.SelectQuery()[0];
                Providers providers = new Providers
                {
                    Id = (int)result[0],
                    Name = (string)result[1],
                    Description = (string)result[2],
                    CreatedDate = (DateTime)result[3],
                    UserId = (int) result[4]
                };
                return providers;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Proveedor con Id {0} no encontrado",id);
            }
            return null;
        }

        public bool Save(Providers providers)
        {
            query = "INSERT INTO providers (name,description,user_id) VALUES(@name,@description,@userId)";
            @params = new Dictionary<string, object>
            {
                {"@name",providers.Name},
                {"@description",providers.Description},
                {"@userId",providers.UserId}
            };
            return base.Execute();
        }

        public bool Update(Providers providers)
        {
            query = "UPDATE  providers SET name=@name,description=@description,created_date=@createdDate, user_id=@userId Where id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",providers.Id},
                {"@name", providers.Name},
                {"@description",providers.Description},
                {"@createdDate",providers.CreatedDate},
                {"@userId",providers.UserId}
            };
            return base.Execute();
        }
    }
}
