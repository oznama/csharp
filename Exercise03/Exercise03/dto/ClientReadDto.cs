using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class ClientReadDto
    {
        private int id;
        private string name;
        private string address;
        private string phone;
        private DateTime createdDate;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }

        public ClientReadDto()
        {

        }
        public ClientReadDto(int id, string name, string address, string phone, DateTime createdDate)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.createdDate = createdDate;
        }
        public override string ToString()
        {
            return "CLIENTS [ID: " + id + ",NAME: " + name + ",ADDRESS: " + address + ",PHONE: " + phone + ",DATE TIME: " + createdDate + "]";
        }
    }
}
