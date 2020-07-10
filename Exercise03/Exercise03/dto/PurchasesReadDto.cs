using System;
using System.Collections;

namespace Exercise03.dto
{
    class PurchasesReadDto
    {

        private int id;
        private DateTime purchaseDate;
        private int userId;
        private int providerId;
        private decimal purchaseTotal;
        private ArrayList productList;

        public int Id { get => id; set => id = value; }
        public DateTime PurchaseDate { get => purchaseDate; set => purchaseDate = value; }
        public int UserId { get => userId; set => userId = value; }
        public int ProviderId { get => providerId; set => providerId = value; }
        public decimal PurchaseTotal { get => purchaseTotal; set => purchaseTotal = value; }
        public ArrayList ProductList { get => productList; set => productList = value; }

        public PurchasesReadDto()
        {
            this.productList = new ArrayList();
        }
        public PurchasesReadDto(int id, DateTime purchaseDate, int userId, int providerId, decimal purchaseTotal)
        {
            this.id = id;
            this.purchaseDate = purchaseDate;
            this.userId = userId;
            this.providerId = providerId;
            this.purchaseTotal = purchaseTotal;
            this.productList = new ArrayList();
        }
        public override string ToString()
        {
            String buffer = String.Format("[ID: {0}] [PURCHASE DATE: {1}] [USER ID: {2}] [PROVIDER ID: {3}] [PURCHASE TOTAL: {4}]",id,purchaseDate,userId,providerId,purchaseTotal);
            foreach (PurchasesItemCreateDto i in productList)
            {
                buffer += "\n\t-" + i.ToString();
            }
            return buffer;
        }

    }
}
