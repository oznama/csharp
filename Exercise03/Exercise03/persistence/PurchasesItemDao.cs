using System;
using System.Collections;
using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    class PurchasesItemDao : BaseDao, IPurchasesItemDao
    {
        public bool Delete(int purchaseId)
        {
            query = "DELETE FROM purchases_item WHERE purchase_id=@purchaseId";
            @params = new Dictionary<string, object>
            {
                {"@purchaseId",purchaseId}
            };
            return base.Execute();
        }

        public IList<PurchasesItem> FindAll()
        {
            query = "SELECT id,product_id,purchase_id, quantity FROM purchases_item";
            @params.Clear();
            IList<PurchasesItem> purchasesItem = new List<PurchasesItem>();
            ArrayList result =base.SelectQuery();
            PurchasesItem purchaseItem;

            foreach(object[] r in result)
            {
                purchaseItem = new PurchasesItem
                {
                    Id = (int)r[0],
                    ProductId = (int)r[1],
                    PurchaseId = (int)r[2],
                    Quantity = (int)r[3]
                };
                purchasesItem.Add(purchaseItem);
            }
            return purchasesItem;
        }

        public PurchasesItem FindById(int id)
        {
            query = "SELECT id, product_id, purchase_id, quantity FROM purchases_item WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            try
            {
                object[] result = (object[])base.SelectQuery()[0];
                PurchasesItem purchasesItem = new PurchasesItem
                {
                    Id = (int)result[0],
                    ProductId = (int)result[1],
                    PurchaseId = (int)result[2],
                    Quantity = (int)result[3]
                };
                return purchasesItem;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("No se encontro el detalle de compra con id {0}", id);
            }
            return null;
        }

        public IList<PurchasesItem> FindByProductId(int productId)
        {
            query = "SELECT id, product_id, purchase_id, quantity FROM purchases_item WHERE product_id=@productId";
            @params = new Dictionary<string, object>
            {
                {"@productId",productId}
            };
            IList<PurchasesItem> purchasesItem = new List<PurchasesItem>();
            ArrayList result = base.SelectQuery();
            PurchasesItem purchaseItem;

            foreach (object[] r in result)
            {
                purchaseItem = new PurchasesItem
                {
                    Id = (int)r[0],
                    ProductId = (int)r[1],
                    PurchaseId = (int)r[2],
                    Quantity = (int)r[3]
                };
                purchasesItem.Add(purchaseItem);
            }
            return purchasesItem;
        }

        public IList<PurchasesItem> FindByPurchaseId(int purchaseId)
        {
            query = "SELECT id, product_id, purchase_id, quantity FROM purchases_item WHERE purchase_id=@purchaseId";
            @params = new Dictionary<string, object>
            {
                {"@purchaseId", purchaseId}
            };
            IList<PurchasesItem> purchasesItem = new List<PurchasesItem>();
            ArrayList result = base.SelectQuery();
            PurchasesItem purchaseItem;

            foreach (object[] r in result)
            {
                purchaseItem = new PurchasesItem
                {
                    Id = (int)r[0],
                    ProductId=(int)r[1],
                    PurchaseId=(int)r[2],
                    Quantity=(int)r[3]
                };
                purchasesItem.Add(purchaseItem);
            }
            return purchasesItem;
        }

        public bool Save(PurchasesItem purchasesItem)
        {
            query = "INSERT INTO purchases_item (product_id,purchase_id, quantity)VALUES (@productId,@purchaseId,@quantity)";
            @params = new Dictionary<string, object>
            {
                {"@productId",purchasesItem.ProductId},
                {"@purchaseId",purchasesItem.PurchaseId},
                {"@quantity",purchasesItem.Quantity}
            };
            return base.Execute();
        }
    }
}
