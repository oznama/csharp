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
        public static Users currentUser;
        public static int currentEmployees;
       
        static void Main(string[] args)
        {
            //UsersTest.testGuardar();
            if (UsersTest.testLogin())
            {
                UsersTest.testUpdateLastAccessDate();
                EmployeesTest.testSave();
                GeneralTest.testSave();
            }
            //UsersTest.testUpdateAll();
            //UsersTest.testCambiarContrasena();
            //UsersTest.testFindAll();

            UsersTest.ShowOneWithRelationships();
            Console.WriteLine();
            EmployeesTest.ShowOneWithRelationship();


            Console.WriteLine("Press ENTER to continue...");
            Console.Read();
        }

    }
}
