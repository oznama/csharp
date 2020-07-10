using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class SaleReadDto
    {
        private int id;
        private DateTime saleDate;
        private int userId;
        private decimal saleTotal;
        private int clientId;
        private bool trusted;

        private ArrayList productList;

        public SaleReadDto(int id, DateTime saleDate, int userId, decimal saleTotal, int clientId, bool trusted)
        {
            this.id = id;
            this.saleDate = saleDate;
            this.userId = userId;
            this.saleTotal = saleTotal;
            this.clientId = clientId;
            this.trusted = trusted;
            this.productList = new ArrayList();
        }

        public int Id { get => id; set => id = value; }
        public DateTime SaleDate { get => saleDate; set => saleDate = value; }
        public int UserId { get => userId; set => userId = value; }
        public decimal SaleTotal { get => saleTotal; set => saleTotal = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public bool Trusted { get => trusted; set => trusted = value; }
        public ArrayList ProductList { get => productList; set => productList = value; }

        public override string ToString()
        {
            String buffer = "[ID: " + id + ",SALE DATE: " + saleDate + ",USER ID: " + userId + ",SALE TOTA: " + saleTotal + ",CLIENT ID: " + clientId + ",TRUSTED: " + trusted + "]";
            foreach(SaleItemCreateDto i in productList)
            {
                buffer += "\n\t-" + i.ToString();
            }
            return buffer;
        }
    }
}
