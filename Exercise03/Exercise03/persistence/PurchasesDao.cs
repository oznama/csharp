using System;
using System.Collections;
using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    class PurchasesDao : BaseDao, IPurchasesDao
    {
        public bool Delete(int id)
        {
            query = "DELETE FROM purchases WHERE id =@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            return base.Execute();
        }
        public IList<Purchases> FindAll()
        {
            query = "SELECT id,purchase_date,user_id,provider_id,purchase_total FROM purchases";
            @params.Clear();
            ArrayList result = base.SelectQuery();
            List<Purchases> purchases = new List<Purchases>();
            Purchases purchase;

            foreach (object[] r in result)
            {
                purchase = new Purchases
                {
                    Id = (int)r[0],
                    PurchaseDate = (DateTime)r[1],
                    UserId=(int)r[2],
                    ProviderId=(int)r[3],
                    PurchaseTotal=(decimal)r[4]                    
                };
                purchases.Add(purchase);
            }
            return purchases;
        }
        public Purchases FindById(int id)
        {
            query = "SELECT id,purchase_date,user_id,provider_id,purchase_total FROM purchases WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            try
            {
                object[] result = (object[])base.SelectQuery()[0];
                Purchases purchases = new Purchases
                {
                    Id=(int)result[0],
                    PurchaseDate=(DateTime)result[1],
                    UserId=(int)result[2],
                    ProviderId=(int)result[3],
                    PurchaseTotal=(decimal)result[4]
                };
                return purchases;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Compra con Id {0} no encontrada",id);
            }
            return null;
        }
        public IList<Purchases> FindByProviderId(int providerId)
        {
            query = "SELECT id,purchase_date,user_id,provider_id,purchase_total FROM purchases WHERE provider_id=@providerId";
            @params = new Dictionary<string, object>
            {
                {"@providerId",providerId}
            };
            ArrayList result = base.SelectQuery();
            List<Purchases> purchases = new List<Purchases>();
            Purchases purchase;

            foreach(object[] r in result)
            {
                purchase = new Purchases
                {
                    Id = (int)r[0],
                    PurchaseDate = (DateTime)r[1],
                    UserId = (int)r[2],
                    ProviderId = (int)r[3],
                    PurchaseTotal = (decimal)r[4],
                };
                purchases.Add(purchase);
            }
            return purchases;
        }
        public IList<Purchases> FindByUserId(int userId)
        {
            query = "SELECT id,purchase_date,user_id,provider_id,purchase_total FROM purchases WHERE user_id=@userId";
            @params = new Dictionary<string, object>
            {
                {"@userId",userId}
            };

            ArrayList result = base.SelectQuery();
            IList<Purchases> purchases = new List<Purchases>();
            Purchases purchase;

            foreach (object[] r in result)
            {
                purchase = new Purchases
                {
                    Id = (int)r[0],
                    PurchaseDate = (DateTime)r[1],
                    UserId = (int)r[2],
                    ProviderId = (int)r[3],
                    PurchaseTotal = (decimal)r[4]
                };
                purchases.Add(purchase);
            }
            return purchases;
        }
        public int Save(Purchases purchases)
        {
            int idGenerated = 0;
            query = "INSERT INTO purchases (user_id,provider_id,purchase_total)VALUES (@userId,@providerId,@purchaseTotal)";
            @params = new Dictionary<string, object>
            {
                {"@userId",purchases.UserId},
                {"@providerId",purchases.ProviderId},
                {"@purchaseTotal",purchases.PurchaseTotal}
            };
            base.Execute(out idGenerated);
            Console.WriteLine("Purchase registred with ID: {0}",idGenerated);
            return idGenerated;
        }
        public bool Update(Purchases purchases)
        {
            query = "UPDATE purchases SET purchase_date=@purchaseDate,user_id=@userId, provider_id=@providerId,purchase_total=@purchaseTotal WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",purchases.Id},
                {"@purchaseDate",purchases.PurchaseDate},
                {"@userId",purchases.UserId},
                {"@providerId",purchases.ProviderId},
                {"@purchaseTotal",purchases.PurchaseTotal}
             };
            return base.Execute();
        }
    }
}
