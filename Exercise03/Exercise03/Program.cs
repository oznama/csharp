using System;
using Exercise03.controller;
using Exercise03.dto;
using Exercise03.view;


namespace Exercise03
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsView productsView = new ProductsView();
            productsView.Menu();
            
            UsersController u = new UsersController();
            UserClientsDto uc = u.GetUserWithClientsCreated(1);
            Console.WriteLine(uc.ToString());

            SalesView salesView = new SalesView();

            salesView.Sale();
            salesView.Search();

            Console.WriteLine("Press ENTER to Continue...");
            Console.Read();
        }
    }
}
