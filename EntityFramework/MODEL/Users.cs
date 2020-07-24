using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.MODEL
{
	class Users
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string FullName { get; set; }
		public string ShortName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Status { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime Createdate { get; set; }
		[Column("lastaccess_date")]
		public DateTime? LastAccessDate { get; set; }
		public string LastAccessIP { get; set; }

		public ICollection<Employees> Employees { get; set; }

        public override string ToString()
        {
			return String.Format("ID: {0}, FULL NAME: {1}, SHORT NAME: {2}, EMAIL: {3}, PASSWORD: {4}, STATUS: {5}, CREATE DATE: {6}, LAST ACCESS DATE: {7}, LAST ACCESS IP{8}",Id,FullName,ShortName,Email,Password,Status,Createdate,LastAccessDate,LastAccessIP);
        }
    }
}
