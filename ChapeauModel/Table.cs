using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Table
    {
        public int Id { get; set; }

        public TableState State { get; set; }

        public int Capacity { get; set; }
    }
}
