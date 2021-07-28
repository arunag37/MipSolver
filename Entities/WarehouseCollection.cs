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

            //3 by 2
            //data 1
            //this.Add(new Warehouse() { Id =0, Name = "BAML", MinUtilization = 55, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2.4, AdvanceRate = 1, PenaltyRate = 2 });
            //this.Add(new Warehouse() { Id =1, Name = "CHASE", MinUtilization = 55, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2, AdvanceRate = 1, PenaltyRate = 2.5 });

            //data 2,4 
            this.Add(new Warehouse() { Id = 0, Name = "BAML", MinUtilization = 60, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 2, AdvanceRate = .9, PenaltyRate = 1.2 });
            this.Add(new Warehouse() { Id = 1, Name = "CHASE", MinUtilization = 60, UtilisedAmount = 40, TotalLimit = 100, InterestRate = 3, AdvanceRate = .9, PenaltyRate = 1.1 });


        }
    }
}
