using System;
using System.Collections.Generic;
using Google.OrTools.LinearSolver;
using MipSolver.Entities;
using System.Linq;

namespace MipSolver
{
    public class Solver1
    {
        public static double Optimizer(IEnumerable<LoanInWarehouse> items, IEnumerable<Loan> loans, IEnumerable<Warehouse> warehouses)
        {
            Solver solver1 = Solver.CreateSolver("SCIP");

            //Variables with combination of loans and warehouse
            Variable[,] x = new Variable[loans.Count(), warehouses.Count()];
            foreach (var loan in loans)
            {
                foreach (var warehouse in warehouses)
                {
                    x[loan.Id, warehouse.Id] = solver1.MakeIntVar(0, 1, $"x_{loan.Id}_{warehouse.Id}");
                }
            }
            //Constraint 1 :Each loan can be assigned to atmost 1 warehouse
            foreach (var loan in loans)
            {
                Constraint constraint = solver1.MakeConstraint(0, 1, "");
                foreach (var warehouse in warehouses)
                {
                    constraint.SetCoefficient(x[loan.Id, warehouse.Id], 1);
                }
            }

            //Constraint 2 :Loan amount assigned to a warehouse can't exceed its limit
            foreach (var warehouse in warehouses)
            {
                var pendingLimit = warehouse.TotalLimit - warehouse.UtilisedAmount;
                Constraint constraint = solver1.MakeConstraint(0, pendingLimit, "");
                foreach (var loan in loans)
                {
                    constraint.SetCoefficient(x[loan.Id, warehouse.Id], loan.LoanAmount * warehouse.AdvanceRate);
                }
            }

            Objective objective = solver1.Objective();
            foreach (var loan in loans)
            {
                foreach (var warehouse in warehouses)
                {
                    objective.SetCoefficient(x[loan.Id, warehouse.Id], loan.LoanAmount * warehouse.AdvanceRate);
                }
            }
            objective.SetMaximization();
            Solver.ResultStatus resultStatus = solver1.Solve();
            if (resultStatus != Solver.ResultStatus.OPTIMAL)
            {
                Console.WriteLine("The problem does not have an optimal solution!");
                return 0;
            }

            return solver1.Objective().Value();
        }
    }
    public class Solver2
    {
        public static double Optimizer(IEnumerable<LoanInWarehouse> items, IEnumerable<Loan> loans, IEnumerable<Warehouse> warehouses, double maxUtilAmt)
        {
            Solver solver2 = Solver.CreateSolver("SCIP");

            //Variables with combination of loans and warehouse


            Variable[,] a = new Variable[loans.Count(), warehouses.Count()];
            foreach (var loan in loans)
            {
                foreach (var warehouse in warehouses)
                {
                    a[loan.Id, warehouse.Id] = solver2.MakeIntVar(0, 1, $"x_{loan.Id}_{warehouse.Id}");
                }
            }
            Variable[] z = new Variable[warehouses.Count()];
            foreach (var warehouse in warehouses)
            {
                z[warehouse.Id] = solver2.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, $"z_{warehouse.Id}");
            }

            //Constraint 1 :Each loan can be assigned to atmost 1 warehouse
            foreach (var loan in loans)
            {
                Constraint constraint = solver2.MakeConstraint(0, 1, "");
                foreach (var warehouse in warehouses)
                {
                    constraint.SetCoefficient(a[loan.Id, warehouse.Id], 1);
                }
            }

            LinearExpr totalLoss = new LinearExpr();
            LinearExpr totalUtilAmount = new LinearExpr();

            foreach (var warehouse in warehouses)
            {
                double amountTemp = warehouse.MinUtilization - warehouse.UtilisedAmount;
                double pendingLimit = warehouse.TotalLimit - warehouse.UtilisedAmount;
                LinearExpr tmpAmount = new LinearExpr();
                LinearExpr tempInterest = new LinearExpr();
                foreach (var loan in loans)
                {
                    //For Interest Calculation
                    tempInterest += (a[loan.Id, warehouse.Id] * (loan.LoanAmount * warehouse.AdvanceRate * warehouse.InterestRate / 100));
                    //For penalty Calculation
                    tmpAmount += (a[loan.Id, warehouse.Id] * loan.LoanAmount * warehouse.AdvanceRate);


                }
                var data = (amountTemp - tmpAmount);
                //Constraint 2 :Loan amount assigned to a warehouse can't exceed its limit
                solver2.Add(tmpAmount <= pendingLimit);

                // Adding constraints for finding absolute value 
                solver2.Add(data <= z[warehouse.Id]);
                solver2.Add(-data <= z[warehouse.Id]);

                //Finding total loss of each warehouse(penalty+interest)
                totalLoss += ((z[warehouse.Id] + data) * warehouse.PenaltyRate / 200) + tempInterest;
                totalUtilAmount += tmpAmount;
            }
            //Constraint 3 : amount utilization should be same as max utilization amount
            solver2.Add(totalUtilAmount == maxUtilAmt);

            //Objective
            solver2.Minimize(totalLoss);
            Solver.ResultStatus resultStatus = solver2.Solve();
            if (resultStatus != Solver.ResultStatus.OPTIMAL)
            {
                Console.WriteLine("The problem does not have an optimal solution!");
                return 0;
            }
            double TotalWeight = 0.0;
            double TotalPenalty = 0.0;
            double TotalUtil = 0;
            foreach (var warehouse in warehouses)
            {
                double BinWeight = 0.0;
                double totalLnAmt = 0.0;
                double utilTemp = 0;
                Console.WriteLine("\n\nWarehouse " + warehouse.Name + "      Limit: " + (warehouse.TotalLimit - warehouse.UtilisedAmount));
                foreach (var loan in loans)
                {
                    if (a[loan.Id, warehouse.Id].SolutionValue() == 1)
                    {
                        Console.WriteLine($"{loan.Name} (Loan Amount: {loan.LoanAmount})");
                        BinWeight += (loan.LoanAmount * warehouse.AdvanceRate * warehouse.InterestRate / 100);
                        totalLnAmt += (loan.LoanAmount * warehouse.AdvanceRate);
                        TotalUtil += loan.LoanAmount * warehouse.AdvanceRate;
                    }
                }
                //Console.WriteLine("Amount Utilized :  " + BinWeight);
                utilTemp = warehouse.MinUtilization - warehouse.UtilisedAmount - totalLnAmt;
                if (utilTemp < 0)
                {
                    utilTemp = 0;
                }

                TotalWeight += BinWeight;
                Console.WriteLine("\nInterest for " + (warehouse.Name) + ":  " + (BinWeight));
                Console.WriteLine("Penalty for " + (warehouse.Name) + "  " + (utilTemp * warehouse.PenaltyRate / 100));
                TotalPenalty += (utilTemp * warehouse.PenaltyRate / 100);
            }
            Console.WriteLine("\n\nTotal Interest: " + TotalWeight);
            Console.WriteLine("Total Penalty: " + TotalPenalty);
            Console.WriteLine("Total Loss: " + (TotalWeight + TotalPenalty));
            Console.WriteLine("Total Utilised amount: " + (TotalUtil));

            return solver2.Objective().Value();
        }


    }
    public class MipSolverOptimizer
    {
        public static void Main()
        {
            var items = new LoanInWarehouseCollection();
            var loans = new LoanCollection();
            var warehouse = new WarehouseCollection();
            //To find the maximum total loan amount which we can distribute among the warehouse lines
            double maxUtilAmt = Solver1.Optimizer(items, loans, warehouse);
            Console.WriteLine("\n\nMaxutilAMt:" + maxUtilAmt);
            //To find the optimized solution
            var data = Solver2.Optimizer(items, loans, warehouse, maxUtilAmt);
            Console.WriteLine("\n\nTotal Loss:" + data);

        }

    }
}
