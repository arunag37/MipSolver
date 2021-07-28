using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MipSolver.Entities
{
    public class OptimizationResults
    {
        public double TotalLoanValue { get; set; }
        public double TotalPenalty { get; set; }
        public double TotalInterest { get; set; }
        public int[] Items { get; set; }

        public string ToString(IEnumerable<LoanInWarehouse> items)
        {
            string result = $"Total Loan Amount: {this.TotalLoanValue},Total Penalty Amount:{this.TotalPenalty},Total Interest Amount:{this.TotalInterest}\r\n";
            var n = this.Items.GetLength(0);
            for (int j = 0; j < n; j++)
            {
                var item = items.Single(i => i.Id == j);
                result += $"Warehouse : {item.Warehouse.Name}, Loan:{item.Loan.Name} : {this.Items[j]}\r\n";
            }
            return result;
        }
    }
}
