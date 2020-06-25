using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class ClientCreateDto
    {
        private string name;
        private string address;
        private string phone;
        private int userId;
        
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public int UserId { get => userId; set => userId = value; }
        
        public ClientCreateDto()
        {

        }
        public ClientCreateDto(string name, string address, string phone, int userId)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.userId = userId;
        }
        public override string ToString()
        {
            return "CLIENTS [NAME: " + name + ",ADDRESS: " + address + ",PHONE: " + phone + ",USER ID: " + userId + "]";
        }
    }
}
