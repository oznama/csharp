using System.Collections;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface IProductsDao
    {
        bool Save(Products products);
        bool Update(Products products);
        bool Delete(int id);
        Products FindById(int id);
        ArrayList FindAll();
    }
}
