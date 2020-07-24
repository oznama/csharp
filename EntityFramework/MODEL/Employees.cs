using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.MODEL
{
	class Employees
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Column("num_employee")]
		public string NumEmployee { get; set; }
		public string FirstName { get; set; }
		public string LastName {get; set;}
		public string Status { get; set; }
		[Column("contract_date")]
		public DateTime ContractDate { get; set; }
		public string Position { get; set; }
		public string Department { get; set; }
		public string Boss { get; set; }
		[Column("users_id")]
		public int UsersId { get; set; }

		public Users User { get; set; }

        public override string ToString()
        {
			return String.Format("Id: {0}, NumEmployee: {1}, FirstName: {2}, LastName: {3}, Status: {4}, ContractDate: {5}, Position: {6}, Department: {7}, Boss: {8}, UsersId:{9}", Id, NumEmployee, FirstName, LastName, Status, ContractDate, Position, Department,Boss, UsersId);
		}
    }
}
