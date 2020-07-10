using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface ISalesDao
    {
        int Save(Sales sales);
        bool Update(Sales sales);
        bool Delete(int id);
        IList<Sales> FindAll();
        Sales FindById(int id);
        IList<Sales> FindByUserId(int userId);
        IList<Sales> FindByClientId(int clientId);
    } 
}
