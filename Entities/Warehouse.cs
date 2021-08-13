using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MipSolver.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double InterestRate { get; set; }
        public double AdvanceRate { get; set; }
        public double PenaltyRate { get; set; }
        public double TotalLimit { get; set; }
        public double StartingBalance { get; set; }
        public double MinUtilization { get; set; }
        public bool IsDummy { get; set; }
    }
}
