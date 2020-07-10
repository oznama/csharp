using System;
using Exercise03.controller;
using Exercise03.model;
using System.Collections;
using System.Text;
using Exercise03.dto;

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
                        Delete();
                        break;
                    case 4:
                        Consult();
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

            if (productsController.Create(new ProductsCreateDto(name, description,shortName,price,stack)))
            {
                Console.WriteLine("\n\t...PRODUCTO AGREGADO CORRECTAMENTE...\n");
            }
            else
            {
                Console.WriteLine("\n\t...PRODUCTO NO AGREGADO...\n");
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

                if (productsController.Update(new ProductsUpdateDto(id, name, description, shortName, price, stack)))
                {
                    Console.WriteLine("\t\n...PRODUCTO ACTUALIZADO CORRECTAMENTE...\n");
                }
                else
                {
                    Console.WriteLine("\t\n...PRODUCTO NO ACTUALIZADO...\n");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\t\n...PRODUCTO NO ACTUALIZADO...\n");
            }
                                          
        }

        public void Delete()
        {
            productsController = new ProductsController();
            Console.WriteLine("\t... DELETE PRODUCT...");
            Console.Write("\nID: ");
            int id = Int32.Parse(Console.ReadLine());

            if (productsController.Delete(id))
            {
                Console.WriteLine("\t\n...PRODUCTO ELIMINADO...\n");
            }
            else
            {
                Console.WriteLine("\t\n...PRODUCTO NO ELININADO...\n");
            }
        }

        public void Consult()
        {
            int op = -1;
            productsController = new ProductsController();

            Console.WriteLine("\t...CONSULT PRODUCT...\n");
            do {
                Console.WriteLine("\t1. CONSULTAR TODOS");
                Console.WriteLine("\t2. CONSULTAR POR ID");
                Console.WriteLine("\t3. REGRESAR");
                Console.Write("\t\nOPCION: ");
                op = Int32.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:         
                        ArrayList result = (ArrayList)productsController.Consult(0);
                        Console.WriteLine("\nPRODUCTOS ENCONTRADOS {0}",result.Count);
                        foreach (Products r in result)
                        {
                            Console.WriteLine(r);
                        }                        
                        break;

                    case 2:
                        Console.Write("\t\n ID: ");
                        int id = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(productsController.Consult(id));
                        break;

                    case 3:
                        Console.Clear();
                        break;

                    default:
                        Console.Write("\t\n...OPCION INVALIDA...");
                        break;
                }
            } while (op!=3);
        }
    }
}
