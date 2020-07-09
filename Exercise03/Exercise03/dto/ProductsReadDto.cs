using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.dto
{
    class ProductsReadDto
    {
        private int id;
        private string name;
        private string description;
        private string shortName;
        private decimal price;
        private int stack;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public decimal Price { get => price; set => price = value; }
        public int Stack { get => stack; set => stack = value; }

        public ProductsReadDto()
        {

        }
        public ProductsReadDto(int id, string name, string description, string shortName, decimal price, int stack)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.shortName = shortName;
            this.price = price;
            this.stack = stack;
        }
        public override string ToString()
        {
            return "[ID: " + id + "] [NAME: " + name + "] [DESCRIPTION: " + description + "] [SHORTNAME: " + shortName + "] [PRICE: " + price + "] [STACK: " + stack + "]";
        }
    }
}
