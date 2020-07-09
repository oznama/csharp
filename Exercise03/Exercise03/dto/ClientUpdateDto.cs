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
        private int userId;
        private DateTime createDate;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public int UserId { get => userId; set => userId = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }

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
        public ClientUpdateDto(int id, string name,string address,string phone, int userId, DateTime createDate)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.userId = userId;
            this.createDate = createDate;
        }                 
        public override string ToString()
        {
            return "CLIENTS [ID: " + id + ",NAME: " + name + ",ADDRESS: " + address + ",PHONE: " + phone + "]";
        }
    }
}
