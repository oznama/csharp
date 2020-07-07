using System;
using System.Collections;
using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    class SalesItemDao : BaseDao, ISalesItemDao
    {
        public bool Delete(int saleId)
        {
            query = "DELETE FROM sales_item WHERE sale_id =@saleId";
            @params = new Dictionary<string, object>
            {
                {"@saleId",saleId}
            };
            return base.Execute();
        }

        public ArrayList FindAll()
        {
            query = "SELECT id,product_id,sale_id,quantity FROM sales_item";
            @params.Clear();
            ArrayList result = base.SelectQuery();
            ArrayList salesItem = new ArrayList();
            SalesItem saleItem;
            foreach (Object [] r in result)
            {
                saleItem = new SalesItem
                {
                    Id = (int)r[0],
                    ProductId=(int)r[1],
                    SaleId=(int)r[2],
                    Quantity=(int)r[3]
                };
                salesItem.Add(saleItem);
            }
            return salesItem;
        }

        public SalesItem FindById(int id)
        {
            query = "SELECT id,product_id,sale_id,quantity FROM sales_item WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            try
            {
                object[] result = (object[])base.SelectQuery()[0];
                SalesItem salesItem = new SalesItem
                {
                    Id = (int)result[0],
                    ProductId=(int)result[1],
                    SaleId=(int)result[2],
                    Quantity=(int)result[3]
                };
                return salesItem;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("No se encontro el detalle de la venta con Id {0}",id);
            }
            return null;
        }

        public ArrayList FindByProductId(int productId)
        {
            query = "SELECT id,product_id,sale_id,quantity FROM sales_item WHERE product_id=@productId";
            @params = new Dictionary<string, object>
            {
                {"@productId",productId}
            };
            ArrayList result = base.SelectQuery();
            ArrayList salesItem = new ArrayList();
            SalesItem saleItem;

            foreach (object[] r in result)
            {
                saleItem = new SalesItem
                {
                    Id=(int)r[0],
                    ProductId=(int)r[1],
                    SaleId=(int)r[2],
                    Quantity=(int)r[3]
                };
                salesItem.Add(saleItem);
            }
            return salesItem;
        }

        public ArrayList FindBySaleId(int saleId)
        {
            query = "SELECT id,product_id,sale_id,quantity FROM sales_item WHERE sale_id=@saleId";
            @params = new Dictionary<string, object>
            {
                {"@saleId",saleId}
            };
            ArrayList result = base.SelectQuery();
            ArrayList salesItem = new ArrayList();
            SalesItem saleItem;

            foreach(object[] r in result)
            {
                saleItem = new SalesItem
                {
                    Id=(int)r[0],
                    ProductId=(int)r[1],
                    SaleId=(int)r[2],
                    Quantity=(int)r[3]
                };
                salesItem.Add(saleItem);
            }
            return salesItem;
        }

        public bool Save(SalesItem salesItem)
        {
            query = "INSERT INTO sales_item (product_id,sale_id, quantity)VALUES (@productId,@saleId,@quantity)";
            @params = new Dictionary<string, object>
            {
                {"@productId",salesItem.ProductId},
                {"@saleId",salesItem.SaleId},
                {"@quantity",salesItem.Quantity}
            };
            return base.Execute();
        }
    }
}
