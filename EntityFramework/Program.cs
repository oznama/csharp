using EntityFramework.MODEL;
using EntityFramework.test;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            //UsersTest.testGuardar();
            UsersTest.testUpdateLastAccessDate();
            //UsersTest.testUpdateAll();
            //UsersTest.testFindAll();

            Console.WriteLine("Press ENTER to continue...");
            Console.Read();
        }
    }
}
