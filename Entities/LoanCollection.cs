using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MipSolver.Entities
{
    public class LoanCollection : List<Loan>
    {
        public LoanCollection()
        {
            //1 by 1
            // this.Add(new Loan() { Id = 0, Name = "Loan-1", LoanAmount = 10, Cost = 2.00 });

            //2 by 2
            ////data 1,2,3
            //this.Add(new Loan() { Id = 0, Name = "Loan-1", LoanAmount = 10, Cost = 2.00 });
            //this.Add(new Loan() { Id = 1, Name = "Loan-2", LoanAmount = 5, Cost = 0.75 });

            //data-4,5
            //this.Add(new Loan() { Id = 0, Name = "Loan-1", LoanAmount = 15, Cost = 2.00 });
            //this.Add(new Loan() { Id = 1, Name = "Loan-2", LoanAmount = 7, Cost = 0.75 });

            //3 by 2
            //data 1,2,3
            //this.Add(new Loan() { Id = 0, Name = "Loan-1", LoanAmount = 10, Cost = 2.00 });
            //this.Add(new Loan() { Id = 1, Name = "Loan-2", LoanAmount = 15, Cost = 0.75 });
            //this.Add(new Loan() { Id = 2, Name = "Loan-3", LoanAmount = 12, Cost = 0.75 });
            ////data 4
            //this.Add(new Loan() { Id = 0, Name = "Loan-1", LoanAmount = 80, Cost = 2.00 });
            //this.Add(new Loan() { Id = 1, Name = "Loan-2", LoanAmount = 15, Cost = 0.75 });
            //this.Add(new Loan() { Id = 2, Name = "Loan-3", LoanAmount = 12, Cost = 0.75 });

            //5 by 3
            //data 1
            this.Add(new Loan() { Id = 0, Name = "Loan-1", LoanAmount = 100, Cost = 2.00 });
            this.Add(new Loan() { Id = 1, Name = "Loan-2", LoanAmount = 200, Cost = 0.75 });
            this.Add(new Loan() { Id = 2, Name = "Loan-3", LoanAmount = 150, Cost = 0.75 });
            this.Add(new Loan() { Id = 3, Name = "Loan-4", LoanAmount = 300, Cost = 0.75 });
            this.Add(new Loan() { Id = 4, Name = "Loan-5", LoanAmount = 75, Cost = 0.75 });
        }
    }
}





