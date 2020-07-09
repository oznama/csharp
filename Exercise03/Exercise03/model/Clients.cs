using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.model
{
    class Clients
    {
        private int id;
        private string name;
        private string address;
        private string phone;
        private int userId;
        private DateTime createdDate;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public int UserId { get => userId; set => userId = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public Clients()
        {

        }
        public Clients(string name, string address, string phone, int userId)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.userId = userId;
        }
        public Clients(int id, string name, string address, string phone, int userId, DateTime createdDate)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.userId = userId;
            this.createdDate = createdDate;
        }
        public override string ToString()
        {
            return "CLIENTS [ID: "+id+",NAME: "+name+",ADDRESS: "+address+",PHONE: "+phone+",USER ID: "+userId+",DATE TIME: "+ createdDate + "]";
        }
    }
}
