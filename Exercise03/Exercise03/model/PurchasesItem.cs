using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.model
{
    class PurchasesItem
    {
        private int id;
        private int productId;
        private int purchaseId;
        private int quantity;

        public int Id { get => id; set => id = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int PurchaseId { get => purchaseId; set => purchaseId = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public PurchasesItem()
        {

        }
        public PurchasesItem(int id, int productId, int purchaseId, int quantity)
        {
            this.id = id;
            this.productId = productId;
            this.purchaseId = purchaseId;
            this.quantity = quantity;       
        }
        public PurchasesItem(int productId, int purchaseId, int quantity)
        {
            this.productId = productId;
            this.purchaseId = purchaseId;
            this.quantity = quantity;
        }
        public override string ToString()
        {
            return "[ID: "+id+",PRODUCT ID: "+productId+",PURCHASE ID: "+productId+",QUANTITY: "+quantity+"]";
        }
    }
}
