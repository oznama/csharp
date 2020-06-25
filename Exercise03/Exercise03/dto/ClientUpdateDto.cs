using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class ClientUpdateDto
    {
        private int id;
        private string name;
        private string address;
        private string phone;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        
        public ClientUpdateDto()
        {

        }
        public ClientUpdateDto(int id, string name, string address, string phone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
        }
        public override string ToString()
        {
            return "CLIENTS [ID: " + id + ",NAME: " + name + ",ADDRESS: " + address + ",PHONE: " + phone + "]";
        }
    }
}
