using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MipSolver.Entities
{
    public class WarehouseCollection : List<Warehouse>
    {
        public WarehouseCollection()
        {
            //1 by 1
            //this.Add(new Warehouse() { Id = 0, Name = "BAML", MinUtilization = 45, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2, AdvanceRate = .9, PenaltyRate = 1.25 });

            //2 by 2
            //data 1
            //this.Add(new Warehouse() { Id = 0, Name = "BAML", MinUtilization = 45, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2.5, AdvanceRate = 1, PenaltyRate = 2 });
            //this.Add(new Warehouse() { Id = 1, Name = "CHASE", MinUtilization = 50, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 3, AdvanceRate = 1, PenaltyRate = 2 });

            //data3
            //this.Add(new Warehouse() { Id = 0, Name = "BAML", MinUtilization = 49, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2.25,AdvanceRate = 1, PenaltyRate = 1 });
            //this.Add(new Warehouse() { Id = 1, Name = "CHASE", MinUtilization = 50, UtilisedAmount = 40, TotalLimit = 100, InterestRate =2.5, AdvanceRate = 1, PenaltyRate = 1.1 });

            //data 4
            //this.Add(new Warehouse() { Id = 0, Name = "BAML", MinUtilization = 60, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2.5, AdvanceRate = .9, PenaltyRate = 1.1 });
            //this.Add(new Warehouse() { Id = 1, Name = "CHASE", MinUtilization = 60, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2.5, AdvanceRate = 1, PenaltyRate = 1 });

            //data 5
            //this.Add(new Warehouse() { Id = 0, Name = "BAML", MinUtilization = 55, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2.5, AdvanceRate = 1, PenaltyRate = 1.5 });
            //this.Add(new Warehouse() { Id = 1, Name = "CHASE", MinUtilization = 60, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2.5, AdvanceRate = 1, PenaltyRate = 1.1 });

            //3 by 2 tested== .0
            //data 1
            //this.Add(new Warehouse() { Id = 0, Name = "Dummy", MinUtilization = 0, UtilisedAmount = 0, TotalLimit = 0, InterestRate = 10000, AdvanceRate = 1, PenaltyRate = 1 });
            //this.Add(new Warehouse() { Id = 1, Name = "BAML", MinUtilization = 55, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2.4, AdvanceRate = 1, PenaltyRate = 2 });
            //this.Add(new Warehouse() { Id = 2, Name = "CHASE", MinUtilization = 55, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2, AdvanceRate = 1, PenaltyRate = 2.5 });

            ////data 2,4 
            //this.Add(new Warehouse() { Id = 0, Name = "BAML", MinUtilization = 600000, UtilisedAmount = 400000, TotalLimit = 1000000, InterestRate = 2, AdvanceRate = .8, PenaltyRate = 1.2 });
            //this.Add(new Warehouse() { Id = 1, Name = "CHASE", MinUtilization = 600000, UtilisedAmount = 400000, TotalLimit = 1000000, InterestRate = 3, AdvanceRate = .9, PenaltyRate = 1.1 });


            //5 by 3
            //data 1 working
            this.Add(new Warehouse() { Id = 0, IsDummy = false, Name = "BAML", MinUtilization = 95, UtilisedAmount = 200000000, TotalLimit = 600000000, InterestRate = 2.1, AdvanceRate = 1, PenaltyRate = 4 });
            this.Add(new Warehouse() { Id = 1, IsDummy = false, Name = "CHASE", MinUtilization = 0, UtilisedAmount = 400000000, TotalLimit = 600000000, InterestRate = 2.2, AdvanceRate = 1, PenaltyRate = 4 });
            this.Add(new Warehouse() { Id = 2, IsDummy = false, Name = "UBS", MinUtilization = 95, UtilisedAmount = 100000000, TotalLimit =  800000000, InterestRate = 2.3, AdvanceRate = 1, PenaltyRate = 5 });
            this.Add(new Warehouse() { Id = 3, IsDummy = false, Name = "UBS1", MinUtilization = 0, UtilisedAmount = 150000000, TotalLimit = 600000000, InterestRate = 2.2, AdvanceRate = 1, PenaltyRate = 5 });
            this.Add(new Warehouse() { Id = 4, IsDummy = false, Name = "UBS2", MinUtilization = 0, UtilisedAmount = 400000000, TotalLimit = 1000000000, InterestRate = 2.1, AdvanceRate = 1, PenaltyRate = 4 });
            this.Add(new Warehouse() { Id = 5, IsDummy = false, Name = "UBS3", MinUtilization = 0, UtilisedAmount = 300000000, TotalLimit = 600000000, InterestRate = 2.4, AdvanceRate = 1, PenaltyRate = 3.6 });
            this.Add(new Warehouse() { Id = 6, IsDummy = false, Name = "UBS4", MinUtilization = 0, UtilisedAmount = 250000000, TotalLimit = 700000000, InterestRate = 2.5, AdvanceRate = 1, PenaltyRate = 4.2 });
            this.Add(new Warehouse() { Id = 7, IsDummy = false, Name = "UBS5", MinUtilization = 0, UtilisedAmount = 150000000, TotalLimit = 200000000, InterestRate = 2.1, AdvanceRate = 1, PenaltyRate = 3 });
            this.Add(new Warehouse() { Id = 8, IsDummy = false, Name = "UBS6", MinUtilization = 0, UtilisedAmount = 1000000, TotalLimit = 600000000, InterestRate = 2.1, AdvanceRate = 1, PenaltyRate = 4 });
            this.Add(new Warehouse() { Id = 9, IsDummy = false, Name = "UBS7", MinUtilization = 0, UtilisedAmount = 300000000, TotalLimit = 1000000000, InterestRate = 2.5, AdvanceRate = 1, PenaltyRate = 2.5 });
            this.Add(new Warehouse() { Id = 10, IsDummy = true, Name = "Dummy1", MinUtilization = 100, UtilisedAmount = 0, TotalLimit = 9999999999900000, InterestRate = 10000, AdvanceRate = 1, PenaltyRate = 1 });
            //this.Add(new Warehouse() { Id = 6, IsDummy = true, Name = "Dummy2", MinUtilization = 100, UtilisedAmount = 0, TotalLimit = 9999999999900000, InterestRate = 10000, AdvanceRate = 1, PenaltyRate = 1 });
            //this.Add(new Warehouse() { Id = 7, IsDummy = true, Name = "Dummy3", MinUtilization = 100, UtilisedAmount = 0, TotalLimit = 9999999999900000, InterestRate = 10000, AdvanceRate = 1, PenaltyRate = 1 });
            //this.Add(new Warehouse() { Id = 8, IsDummy = true, Name = "Dummy4", MinUtilization = 100, UtilisedAmount = 0, TotalLimit = 9999999999900000, InterestRate = 10000, AdvanceRate = 1, PenaltyRate = 1 });

        }
    }
}
