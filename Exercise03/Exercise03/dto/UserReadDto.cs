using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class UserReadDto
    {
        private int id;
        private string userName;
        private string fullName;

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string FullName { get => fullName; set => fullName = value; }

        public UserReadDto()
        {

        }

        public UserReadDto(int id, string userName, string fullName)
        {
            this.id = id;
            this.userName = userName;
            this.fullName = fullName;
        }

        public override string ToString()
        {
            return "USERS [ID: " + id + ",USERNAME: " + userName  + ",FULLNAME: " + fullName + "]";
        }
    }
}
