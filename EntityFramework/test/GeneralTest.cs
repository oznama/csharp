using EntityFramework.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.test
{
    class GeneralTest
    {
		public static void testSave()
        {
			Console.Write("\nRFC: ");
			string rfc = Console.ReadLine();
			Console.Write("\nCURP: ");
			string curp = Console.ReadLine();
			Console.Write("\nNSS: ");
			string nss = Console.ReadLine();
			Console.Write("\nBANK: ");
			string bank = Console.ReadLine();
			Console.Write("\nINTER BANK ACCOUNT: ");
			int clabeInter = int.Parse(Console.ReadLine());

			using (MyContext myContext = new MyContext())
            {
				General general = new General
				{
					EmployeeId = Program.currentEmployees,
					RFC = rfc,
					Curp = curp,
					NSS = nss,
					Bank = bank,
					InterBankAccount = clabeInter,
					UserId = Program.currentUser.Id
				};
				myContext.General.Add(general);
				myContext.SaveChanges();              
            } 		
        }

		public static void testUpdate()
        {

        }
	}
}
