using Exercise03.controller;
using Exercise03.dto;
using Exercise03.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise03.view
{
    class SalesView
    {
        private SalesController saleController;
        private ProductsController productController;

        public void Sale()
        {
            SaleCreateDto sale = new SaleCreateDto();

            saleController = new SalesController();
            productController = new ProductsController();

            Console.Write("\nUsuario id: ");
            sale.UserId = int.Parse(Console.ReadLine());
            Console.Write("\nCliente id: ");
            sale.ClientId = int.Parse(Console.ReadLine());
            Console.Write("\nEs Venta Fiada ?? S | N ");
            sale.Trusted = Console.ReadLine() == "S" ? true : false;

            SaleItemCreateDto item;
            bool @continue = true;
            while (@continue)
            {
                item = new SaleItemCreateDto();
                Console.Write("\n\nProduct Id: ");
                item.ProductId = int.Parse(Console.ReadLine());
                Products product = (Products) productController.Consult(item.ProductId);
                if( product != null )
                {
                    Console.Write("\nCantidad: ");
                    item.Quantity = int.Parse(Console.ReadLine());
                    sale.ProductList.Add(item);
                    sale.Total += product.Price;
                } else
                {
                    Console.Write("\n\n\tProducto no encontrado");
                }
                Console.Write("\n\nAgregar otro producto ?? S | N ");
                @continue = Console.ReadLine() == "S" ? true : false;
            }


            if( saleController.DoSale(sale) )
            {
                Console.WriteLine("\nVenta registrada satisfactoriamente");
            }
        }

        public void Search() {
            saleController = new SalesController();
            Console.Write("\nTipo, 1 byUser, 2 byClient, otherwise All: ");
            byte opt = byte.Parse(Console.ReadLine());
            Console.Write("\nId: ");
            int id = int.Parse(Console.ReadLine());
            IList<SaleReadDto> sales = saleController.Searchs(opt, id);
            foreach(SaleReadDto s in sales)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }
}
