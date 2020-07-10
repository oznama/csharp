using System.Collections;

namespace Exercise03.dto
{
    class SaleCreateDto
    {
        private int userId; // Quien realizo la venta
        private decimal total; // Total de la compra
        private int clientId; // A quien se le esta vendiendo
        private bool trusted; // Fiado
        private ArrayList productList;

        public SaleCreateDto()
        {
            this.productList = new ArrayList();
        }

        public int UserId { get => userId; set => userId = value; }
        public decimal Total { get => total; set => total = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public bool Trusted { get => trusted; set => trusted = value; }
        public ArrayList ProductList { get => productList; set => productList = value; }
    }
}
