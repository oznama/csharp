using System;
using Exercise03.controller;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.view
{
    class ProductsView
    {
        private ProductsController productsController;

        public void Menu()
        {
            int op = -1;

            do
            {
                Console.WriteLine("\t...MENU PRODUCTOS...");
                Console.WriteLine("\t1. Salve");
                Console.WriteLine("\t2. Update");
                Console.WriteLine("\t3. Delete");
                Console.WriteLine("\t4. Consult");
                Console.WriteLine("\t5. Salir");
                Console.Write("\n\tOpcion: ");
                op = Int32.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Save();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("OPCION INVALIDA");
                        break;
                }

            } while (op != 5);    
        }

        public void Save()
        {
            Console.WriteLine("\t...ADD PRODUCT...");

            Console.Write("\nNAME: ");
            string name = Console.ReadLine();

            Console.Write("\nDESCRIPTION: ");
            string description = Console.ReadLine();

            Console.Write("\nSHORTNAME: ");
            string shortName = Console.ReadLine();

            Console.Write("\nPRICE: ");
            Decimal price = Decimal.Parse(Console.ReadLine());

            Console.Write("\nSTACK: ");
            int stack = Int32.Parse(Console.ReadLine());

            productsController = new ProductsController();

            if (productsController.Save(name,description,shortName,price,stack))
            {
                Console.WriteLine("\n\t...PRODUCTO AGREGADO CORRECTAMENTE...");
            }
            else
            {
                Console.WriteLine("\n\t...PRODUCTO NO AGREGADO...");
            }          
        }

        public void Update()
        {
            try
            {
                Console.WriteLine("\t...UPDATE PRODUCT...");

                Console.Write("\nID: ");
                int id = Int32.Parse(Console.ReadLine());

                Console.Write("\nNAME: ");
                string name = Console.ReadLine();

                Console.Write("\nDESCRIPTION: ");
                string description = Console.ReadLine();

                Console.Write("\nSHORTNAME: ");
                string shortName = Console.ReadLine();

                Console.Write("\nPRICE: ");
                decimal price = Decimal.Parse(Console.ReadLine());

                Console.Write("\nSTACK: ");
                int stack = Int32.Parse(Console.ReadLine());

                productsController = new ProductsController();

                if (productsController.Update(id, name, description, shortName, price, stack))
                {
                    Console.WriteLine("\t...PRODUCTO ACTUALIZADO CORRECTAMENTE...");
                }
                else
                {
                    Console.WriteLine("\t...PRODUCTO NO ACTUALIZADO...");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\t...PRODUCTO NO ACTUALIZADO...");
            }
                                          
        }
    }
}
