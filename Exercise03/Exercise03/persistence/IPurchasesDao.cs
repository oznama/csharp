using System.Collections;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface IPurchasesDao
    {
        bool Save(Purchases purchases);
        bool Update(Purchases purchases);
        bool Delete(int id);
        ArrayList FindAll();
        Purchases FindById(int id);
        Purchases FindByProviderId(int providerId);
        Purchases FindByUserId(int userId);
    }
}
