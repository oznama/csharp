using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.model
{
    class SalesItem
    {
        private int id;
        private int productId;
        private int saleId;
        private int quantity;

        public int Id { get => id; set => id = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int SaleId { get => saleId; set => saleId = value;  }
        public int Quantity { get => quantity; set => quantity = value; }

        public SalesItem()
        {

        }
        public SalesItem(int id, int productId, int saleId, int quantity)
        {
            this.id = id;
            this.productId = productId;
            this.saleId = saleId;
            this.quantity = quantity;          
        }
        public SalesItem(int productId, int saleId, int quantity)
        {
            this.productId = productId;
            this.saleId = saleId;
            this.quantity = quantity;
        }
        public override string ToString()
        {
            return "[ID: "+id+",PRODUCT ID: "+productId+",SALE ID: "+saleId+",QUANTITY: "+quantity+"]";
        }
    }
}
