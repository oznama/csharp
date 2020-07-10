using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface IProductsDao
    {
        bool Save(Products products);
        bool Update(Products products);
        bool Delete(int id);
        Products FindById(int id);
        IList<Products> FindAll();
        bool UpdateStack(Products products, SalesItem salesItem);
    }
}
