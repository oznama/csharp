using System.Collections;
using Exercise03.persistence;
using Exercise03.dto;
using Exercise03.model;

namespace Exercise03.controller
{
    class PurchasesController
    {
        private IPurchasesDao purchasesDao;
        private IPurchasesItemDao purchasesItemDao;

        /// <summary>
        /// HACER COMPRA
        /// </summary>
        /// <returns></returns>
        public bool DoPurchases(PurchasesCreateDto purchasesCreateDto)
        {
            purchasesDao = new PurchasesDao();
            purchasesItemDao = new PurchasesItemDao();

            Purchases purchases = new Purchases(purchasesCreateDto.UserId, purchasesCreateDto.ProviderId, purchasesCreateDto.PurchaseTotal);
            int purchasesId = purchasesDao.Save(purchases);
            if (purchasesId>0)
            {
                foreach (PurchasesItemCreateDto i in purchasesCreateDto.ProductList)
                {
                    PurchasesItem pi = new PurchasesItem(i.ProductId,i.PurchaseId,i.Quantity);
                    purchasesItemDao.Save(pi);
                }
            }
            return false;
        }

        public ArrayList Searchs(short option, int id) 
        {
            purchasesDao = new PurchasesDao();
            purchasesItemDao = new PurchasesItemDao();
         
            //FindByUserId
            ArrayList purchases = new ArrayList();
            switch (option)
            {
                case 1:
                    //PROVIDER
                    purchases = purchasesDao.FindByProviderId(id);
                    break;

                case 2:
                    //USER
                    purchases = purchasesDao.FindByUserId(id);
                    break;

                default:
                    //ALL
                    purchases = purchasesDao.FindAll();
                    break;
            }

            ArrayList purchasesReadDto = new ArrayList();
            PurchasesReadDto purchaseReadDto;
            ArrayList items;
            foreach (Purchases p in purchases)
            {
                purchaseReadDto = new PurchasesReadDto(p.Id,p.PurchaseDate,p.UserId,p.ProviderId,p.PurchaseTotal);
                items = purchasesItemDao.FindByPurchaseId(p.Id);
                foreach (PurchasesItem i in items)
                {
                    purchaseReadDto.ProductList.Add(new PurchasesItemCreateDto(i.ProductId,i.PurchaseId,i.Quantity));
                }
                purchasesReadDto.Add(purchaseReadDto);
            }
            return purchasesReadDto;
        }
    }
}
