using System.Collections;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface ISalesDao
    {
        bool Save(Sales sales);
        bool Update(Sales sales);
        bool Delete(int id);
        ArrayList FindAll();
        Sales FindById(int id);
        Sales FindByUserId(int userId);
        Sales FindByClientId(int clientId);
    }
}
