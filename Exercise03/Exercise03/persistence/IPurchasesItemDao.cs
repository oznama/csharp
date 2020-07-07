﻿using System.Collections;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface IPurchasesItemDao
    {
        bool Save(PurchasesItem purchasesItem);
        bool Delete(int purchaseId);
        ArrayList FindAll();
        PurchasesItem FindById(int id);
        ArrayList FindByPurchaseId(int purchaseId);
        ArrayList FindByProductId(int productId);
    }
}
