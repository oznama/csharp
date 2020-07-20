using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.MODEL
{
	class General
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public string RFC { get; set; }
		public string Curp { get; set; }
		public string NSS { get; set; }
		public string Bank { get; set; }
		public int InterBankAccount { get; set; }
		public int UserId { get; set; }

        public override string ToString()
        {
			return String.Format("Id: {0}, EmployeeId: {1}, RFC: {2}, Curp: {3}, NSS: {4}, Bank: {5}, InterBankAccount: {6}, UserId: {7}", Id, EmployeeId, RFC, Curp, NSS, Bank, InterBankAccount, UserId);
        }
	}
}
