using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MipSolver.Entities
{
    public class Tranche
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double InterestRate { get; set; }
        public double AdvanceRate { get; set; }
        public Warehouse warehouse { get; set; }
    }
}
