using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MipSolver.Entities
{
    public class LoanInWarehouse
    {
        public int Id { get; set; }
        public Loan Loan { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
