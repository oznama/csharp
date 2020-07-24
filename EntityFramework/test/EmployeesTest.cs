using EntityFramework.MODEL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.test
{
    class EmployeesTest
    {
        public static int testSave()
        {
			Console.Write("\nEMPLOYEE NUMBER: ");
			string numEmployee = Console.ReadLine();
			Console.Write("\nFIRST NAME: ");
			string firstName = Console.ReadLine();
			Console.Write("\nLAST NAME: ");
			string lastName = Console.ReadLine();
			Console.Write("\nSTATUS: ");
			string status = Console.ReadLine();
			Console.Write("\nCONTRACT DATE [] : ");
			DateTime contractDate = DateTime.Parse(Console.ReadLine());
			Console.Write("\nPOSITION: ");
			string position = Console.ReadLine();
			Console.Write("\nDEPARTMENT: ");
			string department = Console.ReadLine();
			Console.Write("\nBOSS: ");
			string boss = Console.ReadLine();
			
			using (MyContext myContext = new MyContext())
            {
				Employees employees = new Employees
				{
					NumEmployee = numEmployee,
					FirstName = firstName,
					LastName = lastName,
					Status = status,
					ContractDate = contractDate,
					Position = position,
					Department = department,
					Boss = boss,
					UsersId = Program.currentUser.Id
				};
				myContext.Employees.Add(employees);
				myContext.SaveChanges();
				Program.currentEmployees= employees.Id;
			}
			return Program.currentEmployees;
		}

		public static void testUpdateAll()
        {
			using(MyContext myContext = new MyContext())
            {
				Console.Write("\nID: ");
				int id = int.Parse(Console.ReadLine());
				Employees employeesToUpdate = myContext.Employees.Find(id);

                if (id.Equals(employeesToUpdate.Id))
                {
					Console.Write("\nEMPLOYEE NUMBER: ");
					string numEmployee = Console.ReadLine();
					Console.Write("\nFIRST NAME: ");
					string firstName = Console.ReadLine();
					Console.Write("\nLAST NAME: ");
					string lastName = Console.ReadLine();
					Console.Write("\nSTATUS: ");
					string status = Console.ReadLine();
					Console.Write("\nCONTRACT DATE [] : ");
					DateTime contractDate = DateTime.Parse(Console.ReadLine());
					Console.Write("\nPOSITION: ");
					string position = Console.ReadLine();
					Console.Write("\nDEPARTMENT: ");
					string department = Console.ReadLine();
					Console.Write("\nBOSS: ");
					string boss = Console.ReadLine();

					employeesToUpdate.NumEmployee = numEmployee;
					employeesToUpdate.FirstName = firstName;
					employeesToUpdate.LastName = lastName;
					employeesToUpdate.Status = status;
					employeesToUpdate.ContractDate = contractDate;
					employeesToUpdate.Position = position;
					employeesToUpdate.Department = department;
					employeesToUpdate.Boss = boss;

					myContext.SaveChanges();
				}
            }
        }

		/// <summary>
		/// Metodo que realiza consulta OneToOne
		/// </summary>
		public static void ShowOneWithRelationship()
		{
			Console.Write("\nId Empleado: ");
			int employeeId = int.Parse(Console.ReadLine());
			using (MyContext context = new MyContext())
			{
				/* Buscar el empleado con id leido desde consola
				 * SELECT * FROM employees WHERE id = ?;
				 */
				var employee = context.Employees.First(e => e.Id == employeeId);
				Console.WriteLine("Employee finded: {0}\n", employee);

				/*
				 * Busca el registro usuario asociado al empleado 
				 * SELECT u.*
				 * FROM employees e
				 * INNER JOIN users u ON u.id = e.users_id
				 * WHERE e.id = ?;
				 */
				context.Entry(employee).Reference(e => e.User).Load();
				Console.WriteLine("\tCreated by user: {0}", employee.User);
			}
		}
	}
}
