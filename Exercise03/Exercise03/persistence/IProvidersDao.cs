using System.Collections;
using System.Text;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface IProvidersDao
    {
        bool Save(Providers providers);
        bool Update(Providers provaders);
        bool Delete(int id);
        ArrayList FindAll();
        Providers FindById(int id);
    }
}
