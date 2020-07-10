using System.Collections.Generic;
using Exercise03.model;


namespace Exercise03.persistence
{
    interface IClientsDao
    {
        bool Save(Clients clients);
        bool Update(Clients clients);
        bool Delete(int id);
        IList<Clients> FindAll(int id);
        Clients FindById(int id);
        IList<Clients> FindByUser(int userId);
    }
}
