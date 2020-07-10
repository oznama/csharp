using System;
using System.Collections;
using System.Text;

namespace Exercise03.dto
{
    class PurchasesCreateDto
    {
        private int userId;
        private int providerId;
        private decimal purchaseTotal;
        private ArrayList productList;

        public int UserId { get => userId; set => userId = value; }
        public int ProviderId { get => providerId; set => providerId = value; }
        public decimal PurchaseTotal { get => purchaseTotal; set => purchaseTotal = value; }
        public ArrayList ProductList { get => productList; set => productList = value; }
        

        public PurchasesCreateDto()
        {
            this.productList = new ArrayList();

        }
        public PurchasesCreateDto(int userId,int providerId,decimal purchaseTotal)
        {
            this.userId = userId;
            this.providerId = providerId;
            this.purchaseTotal = purchaseTotal;
        }
    }
}
