using EntityFramework.MODEL;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: create all necesary

            using(MyContext myContext=new MyContext())
            {
                Table02 table02 = new Table02
                {
                    Name = "Ruth 25",
                    Description = "Coneja Chota y negra",
                    //Created = DateTime.Now
                };
                myContext.Table02.Add(table02);
                myContext.SaveChanges();

                ICollection<Table02> ListaTable = myContext.Table02.ToList();
                foreach (Table02 List in ListaTable)
                {
                    Console.WriteLine(List.ToString());
                }

            }
            Console.WriteLine("Press ENTER to continue...");
            Console.Read();
        }
    }
}
