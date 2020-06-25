using System;
using System.Collections;
using System.Text;

namespace Exercise03.dto
{
    class UserClientsDto
    {
        private UserDto userDto;
        private ArrayList myClients;

        internal UserDto UserDto { get => userDto; set => userDto = value; }
        public ArrayList MyClients { get => myClients; set => myClients = value; }

        public override string ToString()
        {
            string @return = userDto.ToString();
            foreach(object c in myClients)
            {
                @return += "\n\t" + c.ToString();
            }
            return @return;
        }
    }
}
