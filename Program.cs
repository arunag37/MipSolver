using System;
using System.Collections.Generic;
using Google.OrTools.LinearSolver;
using MipSolver.Entities;
using System.Linq;
using System.Diagnostics;

namespace MipSolver
{
    public class Model
    {
        public static double Normalize( double amount)
        {
            return amount;
        }
        public static double FindMaxUtilAmt(IEnumerable<LoanInWarehouse> items, IEnumerable<Loan> loans, IEnumerable<Warehouse> warehouses)
        {
            Solver solver = Solver.CreateSolver("CBC");
            //Variables with combination of loans and warehouse
            Variable[] a = new Variable[items.Count()];
            foreach (var item in items)
            {
                a[item.Id] = solver.MakeIntVar(0, 1, $"{item.Loan.Name}_{item.Warehouse.Name}");
            }
            ////// dummy Constraint
            foreach (var warehouse in warehouses)
            {
                if (warehouse.IsDummy == true)
                {
                    var warehouseItems = items.Where(r => r.Warehouse.Name == warehouse.Name);
                    Constraint constraint = solver.MakeConstraint(0, 0, "");
                    foreach (var item in warehouseItems)
                    {
                        constraint.SetCoefficient(a[item.Id], 1);
                    }
                }
            }
             
            //Constraint 1 :Each loan can be assigned to atmost 1 warehouse
            foreach (var loan in loans)
            {
                var loanItems = items.Where(r => r.Loan.Name == loan.Name);
                LinearExpr tmpCount = new LinearExpr();
                foreach (var item in loanItems)
                {
                        tmpCount += a[item.Id];
                                       
                }
                solver.Add(tmpCount <= 1);
            }
            LinearExpr totalUtilAmount = new LinearExpr();
            //Constraint 2 :Loan amount assigned to a warehouse can't exceed its limit
            foreach (var warehouse in warehouses)
            {
                if (warehouse.IsDummy == false)
                {
                    LinearExpr tmpAmount = new LinearExpr();
                    var warehouseItems = items.Where(r => r.Warehouse.Name == warehouse.Name);
                    var pendingLimit = warehouse.TotalLimit - warehouse.UtilisedAmount;
                    foreach (var item in warehouseItems)
                    {
                        tmpAmount += (a[item.Id] * Normalize(item.Loan.LoanAmount) * warehouse.AdvanceRate);

                    }
                    //Constraint 2 :Loan amount assigned to a warehouse can't exceed its limit
                    solver.Add(tmpAmount <= Normalize(pendingLimit));

                    //for objective 
                    totalUtilAmount += tmpAmount;
                }

            }
            solver.Maximize(totalUtilAmount);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Solver.ResultStatus resultStatus = solver.Solve();
            stopwatch.Stop();
            Console.WriteLine("\nTime for first solver:" + stopwatch.ElapsedMilliseconds / 1000);
            if (resultStatus != Solver.ResultStatus.OPTIMAL)
            {
                Console.WriteLine("The problem does not have an optimal solution!");
                return 0;
            }

            double TotalWeight = 0.0;
            double TotalUtil = 0;
            foreach (var warehouse in warehouses)
            {
                var warehouseItems = items.Where(r => r.Warehouse.Name == warehouse.Name);
                double BinWeight = 0.0;
                double totalLnAmt = 0.0;

                Console.WriteLine("\n\nWarehouse " + warehouse.Name + "      Limit: " + (warehouse.TotalLimit - warehouse.UtilisedAmount));
                foreach (var item in warehouseItems)
                {
                    if (a[item.Id].SolutionValue() == 1)
                    {
                       // Console.WriteLine($"{item.Loan.Name} (Loan Amount: {item.Loan.LoanAmount})");
                        BinWeight += (item.Loan.LoanAmount * warehouse.AdvanceRate * warehouse.InterestRate / 100);
                        totalLnAmt += (item.Loan.LoanAmount * warehouse.AdvanceRate);
                        TotalUtil += item.Loan.LoanAmount * warehouse.AdvanceRate;
                    }
                }
                //Console.WriteLine("Amount Utilized :  " + BinWeight);             
                TotalWeight += BinWeight;
                Console.WriteLine("Total AMount  " + totalLnAmt);
                Console.WriteLine("Balance  " + (warehouse.TotalLimit - warehouse.UtilisedAmount - totalLnAmt));

            } 
            Console.WriteLine("\n\n Total Utilised amount: " + (TotalUtil));

            return solver.Objective().Value();
        }
        public static double Optimizer(IEnumerable<LoanInWarehouse> items, IEnumerable<Loan> loans, IEnumerable<Warehouse> warehouses, double maxUtilAmt)
        {
            Console.WriteLine("\nMax AMount  " + maxUtilAmt);
            Solver solver = Solver.CreateSolver("CBC");
            //Variables with combination of loans and warehouse
            Variable[] a = new Variable[items.Count()];
            foreach (var item in items)
            {
                a[item.Id] = solver.MakeIntVar(0, 1, $"{item.Loan.Name}_{item.Warehouse.Name}");
            }
            Variable[] z = new Variable[warehouses.Count()];
            foreach (var warehouse in warehouses)
            {
                z[warehouse.Id] = solver.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, $"z_{warehouse.Id}");
            }
            // dummy Constraint
            double dummypenalty = 0;
            foreach (var warehouse in warehouses)
            {
                if (warehouse.IsDummy==true)
                {
                    var warehouseItems = items.Where(r => r.Warehouse.Name == warehouse.Name);
                    LinearExpr tmpCount = new LinearExpr();

                    foreach (var item in warehouseItems)
                    {
                        tmpCount += a[item.Id];
                        
                    }
                    solver.Add(tmpCount == 0);
                    dummypenalty += (warehouse.TotalLimit * warehouse.MinUtilization / 100) * warehouse.PenaltyRate / 100;
                }
               
            }
            //Constraint 1 :Each loan can be assigned to atmost 1 warehouse 
           
            foreach (var loan in loans)
            {
                var loanItems = items.Where(r => r.Loan.Name == loan.Name);
                LinearExpr tmpCount = new LinearExpr();
                foreach (var item in loanItems)
                {
                    tmpCount += a[item.Id];                  
                }
                solver.Add(tmpCount <= 1);
            }

            LinearExpr totalLoss = new LinearExpr();
            LinearExpr totalUtilAmount = new LinearExpr();

            foreach (var warehouse in warehouses)
            {
                var warehouseItems = items.Where(r => r.Warehouse.Name == warehouse.Name);
                                   
                double amountTemp = (warehouse.TotalLimit * warehouse.MinUtilization / 100) - warehouse.UtilisedAmount;
                double pendingLimit = warehouse.TotalLimit - warehouse.UtilisedAmount;
                LinearExpr tmpAmount = new LinearExpr();
                LinearExpr tempInterest = new LinearExpr();
                foreach (var item in warehouseItems)
                {
                    //For Interest Calculation
                    tempInterest += (a[item.Id] * Normalize(item.Loan.LoanAmount) * warehouse.AdvanceRate * warehouse.InterestRate) / 100;
                    //For penalty Calculation
                    tmpAmount += (a[item.Id] * Normalize(item.Loan.LoanAmount) * warehouse.AdvanceRate);

                }
                var data = (Normalize(amountTemp) - tmpAmount);
                //Constraint 2 :Loan amount assigned to a warehouse can't exceed its limit
                solver.Add(tmpAmount <= Normalize(pendingLimit));

                // Adding constraints for finding absolute value 
                solver.Add(data <= z[warehouse.Id]);
                solver.Add(-data <= z[warehouse.Id]);

                //Finding total loss of each warehouse(penalty+interest)
                totalLoss += ((z[warehouse.Id] + data) * warehouse.PenaltyRate) / 200 + tempInterest;
                totalUtilAmount += tmpAmount;
               

            }
            //Constraint 3 : amount utilization should be same as max utilization amount
            solver.Add(totalUtilAmount >= (maxUtilAmt));

            //Objective
            solver.Minimize((totalLoss));
            var stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            Solver.ResultStatus resultStatus = solver.Solve();
            stopwatch1.Stop();
            Console.WriteLine("\nTime for second solver:" + stopwatch1.ElapsedMilliseconds / 1000);
            if (resultStatus != Solver.ResultStatus.OPTIMAL)
            {
                Console.WriteLine("The problem does not have an optimal solution!");
                return 0;
            }
            double TotalWeight = 0.0;
            double TotalPenalty = 0.0;
            double TotalUtil = 0;
            double TotalLoanCount = 0;
            foreach (var warehouse in warehouses)
            {
                var warehouseItems = items.Where(r => r.Warehouse.Name == warehouse.Name);
                double BinWeight = 0.0;
                double totalLnAmt = 0.0;
                double utilTemp = 0;
                Console.WriteLine("\n\nWarehouse " + warehouse.Name + "      Limit: " + (warehouse.TotalLimit - warehouse.UtilisedAmount));
                foreach (var item in warehouseItems)
                {
                    if (a[item.Id].SolutionValue() == 1)
                    {
                        Console.WriteLine($"{item.Loan.Name} (Loan Amount: {item.Loan.LoanAmount})");
                        BinWeight += (item.Loan.LoanAmount * warehouse.AdvanceRate * warehouse.InterestRate / 100);
                        totalLnAmt += (item.Loan.LoanAmount * warehouse.AdvanceRate);
                        TotalUtil += item.Loan.LoanAmount * warehouse.AdvanceRate;
                        TotalLoanCount++;
                    }
                }
                //Console.WriteLine("Amount Utilized :  " + BinWeight);
                utilTemp = (warehouse.TotalLimit * warehouse.MinUtilization / 100) - warehouse.UtilisedAmount - totalLnAmt;
                if (utilTemp < 0)
                {
                    utilTemp = 0;
                }

                TotalWeight += BinWeight;
                Console.WriteLine("\nTotal AMount  " + totalLnAmt);
                Console.WriteLine("\nBalance  " + (warehouse.TotalLimit - warehouse.UtilisedAmount - totalLnAmt));
                Console.WriteLine("\nInterest for " + (warehouse.Name) + ":  " + (BinWeight));
                Console.WriteLine("Penalty for " + (warehouse.Name) + "  " + (utilTemp * warehouse.PenaltyRate / 100));
                TotalPenalty += (utilTemp * warehouse.PenaltyRate / 100);
            }
            
            Console.WriteLine("\n\nTotal Interest: " + TotalWeight);
            Console.WriteLine("Total Penalty: " + TotalPenalty);
            Console.WriteLine("Total Loss: " + (TotalWeight + TotalPenalty - dummypenalty));
            Console.WriteLine("Total Utilised amount: " + (TotalUtil));
            Console.WriteLine("Total Loan Alloted : " + (TotalLoanCount)); 

            return solver.Objective().Value() - dummypenalty;
        }

    }
 
    public class MipSolverOptimizer
    {
       
        public static void Main()
        {
            var items = new LoanInWarehouseCollection();
            var loans = new LoanCollection();
            var warehouse = new WarehouseCollection();
            //int i = 0;
            //foreach (var loan in loans)
            //{
            //    Console.WriteLine($"this.Add(new Loan() # Id ={i}, Name = \"{loan.Name}\" LoanAmount = {loan.LoanAmount}, Cost = 2.00 @);");
            //    i++;

            //}
            //To find the maximum total loan amount which we can distribute among the warehouse lines

            double maxUtilAmt = Model.FindMaxUtilAmt(items, loans, warehouse);
            Console.WriteLine("\n\nMaxutilAMt:" + (maxUtilAmt));

            //To find the optimized solution

            var data = Model.Optimizer(items, loans, warehouse, maxUtilAmt);
            Console.WriteLine("\n\nTotal Loss:" + data);



        }

    }
}
