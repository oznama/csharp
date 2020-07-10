using System.Collections;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface IPurchasesDao
    {
        int Save(Purchases purchases);
        bool Update(Purchases purchases);
        bool Delete(int id);
        ArrayList FindAll();
        Purchases FindById(int id);
        ArrayList FindByProviderId(int providerId);
        ArrayList FindByUserId(int userId);
    }
}
