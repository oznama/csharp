using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.model
{
    class Products
    {
        private int id;
        private string name;
        private string description;
        private string shortName;
        private decimal price;
        private int stack;

        /// <summary>
        /// Encapsulando Campos:
        /// id,name, description, shortName, price, stack
        /// y usar campos
        /// </summary>
        
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string ShortName { get => shortName; set => shortName = value; }
        public decimal Price { get => price; set => price = value; }
        public int Stack { get => stack; set => stack = value; }

        public Products()
        {

        }
        public Products(int id, string name, string description, string shortName, decimal price, int stack)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.shortName = shortName;
            this.price = price;
            this.stack = stack;
        }
        public Products(string name, string description, string shortName, decimal price, int stack)
        {
            this.name = name;
            this.description = description;
            this.shortName = shortName;
            this.price = price;
            this.stack = stack;
        }

        public override string ToString()
        {
            return "PRODUCTS [ID: " + id + ",NAME: " + name + ",DESCRIPTION: " + description + ",SHORTNAME: " + shortName + ",PRICE: " + price + ",STACK: " + stack + "]";
        }
    }
}
