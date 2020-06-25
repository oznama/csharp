using System;
using System.Collections;
using System.Text;
using Exercise03.model;


namespace Exercise03.persistence
{
    interface IClientsDao
    {
        bool Save(Clients clients);
        bool Update(Clients clients);
        bool Delete(int id);
        ArrayList FindAll(int id);
        Clients FindById(int id);
    }
}
