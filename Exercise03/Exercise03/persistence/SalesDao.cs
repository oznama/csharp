using System;
using System.Collections;
using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    class SalesDao : BaseDao, ISalesDao
    {
        public bool Delete(int id)
        {
            query = "DELETE FROM sales WHERE id =@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            return base.Execute();
        }

        public ArrayList FindAll()
        {
            query = "SELECT id, sale_date,user_id,sale_total,client_id,trusted FROM sales";
            @params.Clear();

            ArrayList result = base.SelectQuery();
            ArrayList sales = new ArrayList();
            Sales sale;

            foreach(object []r in result)
            {
                sale = new Sales
                {
                    Id = (int)r[0],
                    SaleDate=(DateTime)r[1],
                    UserId=(int)r[2],
                    SaleTotal=(decimal)r[3],
                    ClientId=(int)r[4],
                    Trusted=(byte)r[5]
                };
                sales.Add(sale);
            }
            return sales;
        }
        public Sales FindByClientId(int clientId)
        {
            query = "SELECT id, sale_date,user_id,sale_total,client_id,trusted FROM sales WHERE client_id=@clientId";
            @params = new Dictionary<string, object>
            {
                {"@clientId",clientId}
            };
            try
            {
                object[] result = (object [])base.SelectQuery()[0];
                Sales sales = new Sales
                {
                    Id=(int)result[0],
                    SaleDate=(DateTime)result[1],
                    UserId=(int)result[2],
                    SaleTotal=(decimal)result[3],
                    ClientId=(int)result[4],
                    Trusted=(byte)result[5]
                };
                return sales;
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("No se encontraron ventas relacionadas al Cliente con Id: {0}",clientId);
            }
            return null;
        }

        public Sales FindById(int id)
        {
            query = "SELECT id, sale_date,user_id,sale_total,client_id,trusted FROM sales WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            try
            {
                object[] result = (object[])base.SelectQuery()[0];
                Sales sales = new Sales
                {
                    Id=(int)result[0],
                    SaleDate=(DateTime)result[1],
                    UserId=(int)result[2],
                    SaleTotal=(decimal)result[3],
                    ClientId=(int)result[4],
                    Trusted=(byte)result[5]
                };
                return sales;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("No se encontraron ventas con Id: {0}",id);
            }
            return null;
        }

        public Sales FindByUserId(int userId)
        {
            query = "SELECT id, sale_date,user_id,sale_total,client_id,trusted FROM sales WHERE user_id=@userId";
            @params = new Dictionary<string, object>
            {
                {"@userId",userId}
            };
            try
            {
                object[] result =(object[])base.SelectQuery()[0];
                Sales sales = new Sales
                {
                    Id = (int)result[0],
                    SaleDate = (DateTime)result[1],
                    UserId = (int)result[2],
                    SaleTotal=(decimal)result[3],
                    ClientId=(int)result[4],
                    Trusted=(byte)result[5]
                };
                return sales;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("No se encontraron ventas relaconadas al Usuario con Id: {0}",userId);
            }
            return null;
        }

        public bool Save(Sales sales)
        {
            query = "INSERT INTO sales (user_id,sale_total,client_id,trusted)VALUES (@userId,@saleTotal,@clientId,@trusted)";
            @params = new Dictionary<string, object>
            {
                {"@userId",sales.UserId},
                {"@saleTotal",sales.SaleTotal},
                {"@clientId",sales.ClientId},
                {"@trusted",sales.Trusted}
            };
            return base.Execute();
        }

        public bool Update(Sales sales)
        {
            query = "UPDATE sales SET user_id=@userId,sale_total=@saleTotal,client_id=@clientId,trusted=@trusted WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",sales.Id},
                {"@userId",sales.UserId},
                {"@saleTotal",sales.SaleTotal},
                {"@clientId",sales.ClientId},
                {"@trusted",sales.Trusted}
            };
            return base.Execute();
        }
    }
}
