using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.model
{
    class Purchases
    {
        private int id;
        private DateTime purchaseDate;
        private int userId;
        private int providerId;
        private decimal purchaseTotal;   

        public int Id { get => id; set => id = value; }
        public DateTime PurchaseDate { get => purchaseDate; set => purchaseDate = value; }
        public int UserId { get => userId; set => userId = value; }
        public int ProviderId { get => providerId; set => providerId = value; }
        public decimal PurchaseTotal { get => purchaseTotal; set => purchaseTotal = value; }

        public Purchases()
        {

        }
        public Purchases(int id, DateTime purchaseDate, int userId, int providerId, decimal purchaseTotal)
        {
            this.id = id;
            this.purchaseDate = purchaseDate;
            this.userId = userId;
            this.providerId = providerId;
            this.purchaseTotal = purchaseTotal;            
        }
        public Purchases(int userId, int providerId, decimal purchaseTotal)
        {
            this.userId = userId;
            this.providerId = providerId;
            this.purchaseTotal = purchaseTotal;
        }
        public override string ToString()
        {
            return "[ID: "+id+",PURCHASE DATE: "+purchaseDate+",USER ID: "+userId+",PROVIDER ID: "+providerId+",PURCHASE TOTAL: "+purchaseTotal+"]";
        }
    }
}
