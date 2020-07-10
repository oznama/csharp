using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface IPurchasesDao
    {
        int Save(Purchases purchases);
        bool Update(Purchases purchases);
        bool Delete(int id);
        IList<Purchases> FindAll();
        Purchases FindById(int id);
        IList<Purchases> FindByProviderId(int providerId);
        IList<Purchases> FindByUserId(int userId);
    }
}
