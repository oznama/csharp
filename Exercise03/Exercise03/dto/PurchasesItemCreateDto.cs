using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class PurchasesItemCreateDto
    {
        private int productId;
        private int purchaseId;
        private int quantity;

        public int ProductId { get => productId; set => productId = value; }
        public int PurchaseId { get => purchaseId; set => purchaseId = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public PurchasesItemCreateDto()
        {

        }
        public PurchasesItemCreateDto(int productId,int purchaseId,int quantity)
        {
            this.productId = productId;
            this.purchaseId = purchaseId;
            this.quantity = quantity;
        }
        public override string ToString()
        {
            return "[PRODUCT ID: "+productId+"] [PURCHASE ID: "+purchaseId+"] [QUANTITY: "+quantity+"]";
        }
    }
}
