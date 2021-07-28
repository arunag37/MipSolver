using System;
using System.Collections.Generic;
using System.Text;

namespace MipSolver
{
    public class Models
    {
        public class Loan
        {
            public int Id { get; set; }
            public string LoanNo { get; set; }
            public decimal LoanAmount { get; set; }
            public List<string> Tranch { get; set; }
        }


        public class Tranch
        {
            public int Id { get; set; }
            public string TranchName { get; set; }
            public decimal TranchLimit { get; set; }
            public decimal PriceRate { get; set; }
            public decimal AdvanceRate { get; set; }

        }

        public class TranchWithLoans
        {
            public string TranchName { get; set; }
            public List<string> LoanName { get; set; }

        }


    }
}

