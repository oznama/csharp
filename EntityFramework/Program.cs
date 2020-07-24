using EntityFramework.MODEL;
using EntityFramework.test;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
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
            EmployeesTest.ShowOneWithRelationships();


            Console.WriteLine("Press ENTER to continue...");
            Console.Read();
        }

    }
}
