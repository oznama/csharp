using System.Collections.Generic;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface IPurchasesItemDao
    {
        bool Save(PurchasesItem purchasesItem);
        bool Delete(int purchaseId);
        IList<PurchasesItem> FindAll();
        PurchasesItem FindById(int id);
        IList<PurchasesItem> FindByPurchaseId(int purchaseId);
        IList<PurchasesItem> FindByProductId(int productId);
    }
}
