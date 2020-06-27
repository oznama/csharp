using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.model
{
    class Sales
    {
        private int id;
        private DateTime saleDate;
        private int userId;
        private decimal saleTotal;
        private int clientId;
        private byte trusted;

        public int Id { get => id; set => id = value; }
        public DateTime SaleDate { get => saleDate; set => saleDate = value; }
        public int UserId { get => userId; set => userId = value; }
        public decimal SaleTotal{ get => saleTotal; set => saleTotal = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public byte Trusted { get => trusted; set => trusted = value; }

        public Sales()
        {

        }

        public Sales(int id, DateTime saleDate, int userId, decimal saleTotal, int clientId, byte trusted)
        {
            this.id = id;
            this.saleDate = saleDate;
            this.userId = userId;
            this.saleTotal = saleTotal;
            this.clientId = clientId;
            this.trusted = trusted;
        }

        public Sales(int userId, decimal saleTotal, int clientId, byte trusted)
        {
            this.userId = userId;
            this.saleTotal = saleTotal;
            this.clientId = clientId;
            this.trusted = trusted;
        }

        public override string ToString()
        {
            return "[ID: "+id+",SALE DATE: "+saleDate+",USER ID: "+userId+",SALE TOTA: "+saleTotal+",CLIENT ID: "+clientId+",TRUSTED: "+trusted+"]";
        }
    }
}
