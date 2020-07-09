using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class ProductsCreateDto
    {
        private string name;
        private string description;
        private string shortName;
        private decimal price;
        private int stack;

        
        public string Name { get => name;set => name = value; }
        public string Description { get => description; set => description = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public decimal Price { get => price; set => price = value; }
        public int Stack { get => stack; set => stack = value; }

        public ProductsCreateDto()
        {

        }
        public ProductsCreateDto(string name, string description,string shortName,decimal price,int stack)
        {
            this.name = name;
            this.description = description;
            this.shortName = shortName;
            this.price = price;
            this.stack = stack;
        }

        public override string ToString()
        {
            return "[NAME: "+name+"] [DESCRIPTION: " +description+"] [SHORT NAME: "+shortName+"] [PRICE: "+price+"] [STACK: "+stack+"]";
        }
    }
}
