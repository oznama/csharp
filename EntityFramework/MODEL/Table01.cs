using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.MODEL
{
    class Table01
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return String.Format("Table 01 [ID: {0} NAME: {1} DESCRIPTION: {2}]",Id,Name,Description);
        }

    }
}
