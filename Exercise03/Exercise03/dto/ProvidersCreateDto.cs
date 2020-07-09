using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class ProvidersCreateDto
    {
        private string name;
        private string description;
        private int userId;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int UserId { get => userId; set => userId = value; }

        public ProvidersCreateDto()
        {

        }
        public ProvidersCreateDto(string name,string description,int userId)
        {
            this.name = name;
            this.description = description;
            this.userId = userId;
        }
        public override string ToString()
        {
            return "[NAME: "+name+"] [DESCRIPTION: "+description+"] [USER ID: "+userId+"]";
        }

    }
}
