using System;
using System.Collections;
using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    class ProductsDao : BaseDao, IProductsDao
    {
        public bool Delete(int id)
        {
            query= "DELETE FROM products WHERE id =@id";
            @params = new Dictionary<string, object>
            {
                { "@id",id }
            };
            return base.Execute();            
        }

        public ArrayList FindAll()
        {
            query = "SELECT id, name, description, short_name, price, stack FROM products;";
            @params.Clear();
            ArrayList products = new ArrayList();
            ArrayList result = base.SelectQuery();
            Products product;
            foreach (object[] r in result)
            {
                product = new Products
                {
                    Id = (int)r[0],
                    Name = (string)r[1],
                    Description = (string)r[2],
                    ShortName = (string)r[3],
                    Price = (decimal)r[4],
                    Stack = (int)r[5]
                };
                products.Add(product);
            }
            return products;
        }

        public Products FindById(int id)
        {
            query = "SELECT id,name,description,short_name,price,stack FROM products WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id }
            };
            try
            {
                object[] result = (object[])base.SelectQuery()[0];
                Products product = new Products()
                {
                    Id = (int)result[0],
                    Name = (string)result[1],
                    Description = (string)result[2],
                    ShortName = (string)result[3],
                    Price = (decimal)result[4],
                    Stack = (int)result[5]
                };
                return product;
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Producto con ID {0} no encontrado",id);
            }
            return null;
        }

        public bool Save(Products products)
        {
            query = "INSERT INTO products (name, description, short_name, price, stack) VALUES (@name, @description,@shortName,@price,@stack)";
            @params = new Dictionary<string, object>
            {
                {"@name", products.Name},
                {"@description", products.Description},
                {"@shortName",products.ShortName},
                {"@price",products.Price},
                {"@stack",products.Stack}
            };
            return base.Execute();
        }

        public bool Update(Products products)
        {
            query = "UPDATE products SET name=@name,description=@description,short_name=@shortName,price=@price,stack=@stack WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",products.Id},
                {"@name",products.Name},
                {"@description",products.Description},
                {"@shortName",products.ShortName},
                {"@price",products.Price},
                {"@stack",products.Stack}                  
            };
            return base.Execute();
        }
    }
}
