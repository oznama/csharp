using System.Collections;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface ISalesDao
    {
        int Save(Sales sales);
        bool Update(Sales sales);
        bool Delete(int id);
        ArrayList FindAll();
        Sales FindById(int id);
        ArrayList FindByUserId(int userId);
        ArrayList FindByClientId(int clientId);
    }
}
