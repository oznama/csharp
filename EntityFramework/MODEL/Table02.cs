using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.MODEL
{
    class Table02
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }


        public override string ToString()
        {
            return String.Format("Table 02 [ID: {0} NAME: {1} DESCRIPTION: {2} CREATED: {3}]",Id,Name,Description,Created);
        }
    }
}
