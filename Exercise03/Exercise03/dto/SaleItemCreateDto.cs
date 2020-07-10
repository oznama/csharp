using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class SaleItemCreateDto
    {
        private int productId; // Identificador del producto
        private int saleId; // Identificador de la venta
        private int quantity; // Cantidad comprada del producto

        public SaleItemCreateDto()
        {
        }

        public SaleItemCreateDto(int productId, int saleId, int quantity)
        {
            this.productId = productId;
            this.saleId = saleId;
            this.quantity = quantity;
        }

        public int ProductId { get => productId; set => productId = value; }
        public int SaleId { get => saleId; set => saleId = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public override string ToString()
        {
            return "[PRODUCT ID: " + productId + ",SALE ID: " + saleId + ",QUANTITY: " + quantity + "]";
        }
    }
}
