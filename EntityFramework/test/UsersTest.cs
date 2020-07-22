using EntityFramework.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace EntityFramework.test
{
    class UsersTest
    {
        public static bool testLogin()
        {
            // TODO: programar login

            Console.Write("\nUser: ");
            string email=Console.ReadLine();
            Console.Write("\nPassword: ");
            string password = readLinePassword();
            Console.WriteLine("\nPassword: {0}", password);

            using (MyContext context = new MyContext())
            {
                //Program.currentUser = context.Users.Where(u => u.Email == email && u.Password == password).Single();
                Program.currentUser = context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
                return Program.currentUser != null;
            }

        }
        public static void testGuardar()
        {
            // Con esto puedo recuperar la IP de una maquina

            Console.Write("\nFullName: ");
            string fullname = Console.ReadLine();

            Console.Write("\nShort Name: ");
            string shortName = Console.ReadLine();

            Console.Write("\nEmail: ");
            string email = Console.ReadLine();

            Console.Write("\nPassword: ");
            string password = Console.ReadLine();

            Console.Write("\nStatus: [1. Activo, 2.Inactivo]: ");
            int op = int.Parse(Console.ReadLine());
            // string opselec = op == 1 ? "Activo" : "Inactivo";
            string opselect = op == 1 ? "Activio" : (op == 2 ? "Inactivo": "Invalido");

            string hostname = Dns.GetHostName();
            Console.WriteLine(hostname);
            IPAddress ipAddress = Dns.GetHostEntry(hostname)
                .AddressList
                .FirstOrDefault(
                    a => a.AddressFamily == AddressFamily.InterNetwork
                );
            using (MyContext myContext = new MyContext())
            {

                Users user = new Users
                {
                    FullName = fullname,
                    ShortName = shortName,
                    Email = email,
                    Password = password,
                    Status = opselect,
                    LastAccessIP = ipAddress.ToString()
                };
                myContext.Users.Add(user);
                myContext.SaveChanges();
            }
        }
        public static void testCambiarContrasena()
        {
            using (MyContext myContext = new MyContext())
            {

                Console.Write("\nID: ");
                int id = int.Parse(Console.ReadLine());

                Users userToUpdate = myContext.Users.Find(id);
                Console.Write("\nEscribe Contrasena Actual: ");
                string passActual = Console.ReadLine();

                if (passActual.Equals(userToUpdate.Password))
                {
                    Console.Write("\nEscribe Contrasena nueva: ");
                    passActual = Console.ReadLine();
                    userToUpdate.Password = passActual;
                    myContext.SaveChanges();
                }
            }
        }
        public static void testUpdateLastAccessDate()
        {
            using (MyContext myContext = new MyContext())
            {
                Program.currentUser = myContext.Users.Find(Program.currentUser.Id);
                Program.currentUser.LastAccessDate = DateTime.Now;
                myContext.SaveChanges();
            }
        }
        public static void testFindAll()
        {
            using (MyContext myContext = new MyContext())
            {

                ICollection<Users> users = myContext.Users.ToList();
                foreach (Users us in users)
                {
                    Console.WriteLine(us.ToString());
                }
            }
        }
        public static void testUpdateAll()
        {
            using (MyContext myContext = new MyContext())
            {
                Console.Write("\nID:");
                int id = int.Parse(Console.ReadLine());
                Users userToUpdate = myContext.Users.Find(id);

                if (id.Equals(userToUpdate.Id))
                {
                    Console.Write("\nFull Name: ");
                    string fullName = Console.ReadLine();
                    Console.Write("\nShort Name: ");
                    string shortName = Console.ReadLine();
                    Console.Write("\nEmail: ");
                    string email = Console.ReadLine();
                    Console.Write("\nStatus: ");
                    string status = Console.ReadLine();

                    userToUpdate.FullName = fullName;
                    userToUpdate.ShortName = shortName;
                    userToUpdate.Email = email;
                    userToUpdate.Status = status;
                    myContext.SaveChanges();
                }

             }

        }

        private static string readLinePassword()
        {
            string pass = ""; // Variable que concatena las letras que se van ingresando en consola
            do // Un ciclo infinito hasta que se oprima "ENTER"
            {
                ConsoleKeyInfo teclaApretada = Console.ReadKey(true); // Se recupera la tecla apretada desde consola
                                                            // y se guarda en un objeto de tipo ConsoleKeyInfo
                // Se compara que la tecla presionada no sea ni Backspace (Borrar) ni ENTER
                if (teclaApretada.Key != ConsoleKey.Backspace && teclaApretada.Key != ConsoleKey.Enter)
                {
                    pass += teclaApretada.KeyChar; // Se concatena el valor de la techa a la cadena pass
                    Console.Write("*"); // Se pinta en consola un asterisco
                }
                else // Si la tecla apretada si fue Backspace o ENTER
                {
                    // Si la tecla apretada es backespace y la cadena pass ya tiene una longitud mayor de 0
                    if (teclaApretada.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1)); // Se substrae el ultimo caracter de pass
                        Console.Write("\b \b"); // Se borra un asterisco de la cadena de asteriscos ya pintadas en consola
                    }
                    // Si la tecla apretada es ENTER, se termina el ciclo infinito
                    else if (teclaApretada.Key == ConsoleKey.Enter)
                    {
                        break; // Rompe el ciclo infinito
                    }
                }
            } while (true);
            return pass; // Devuelve la variable pass con las letras de la contrasenia escritas desde consola
        }
    }
}
