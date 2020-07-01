using System;
using System.Collections;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface ISalesItemDao
    {
        bool Save(SalesItem salesItem);
        bool Update(SalesItem salesItem);
        bool Delete(int saleId);
        ArrayList FindAll();
        SalesItem FindById();
    }
}
