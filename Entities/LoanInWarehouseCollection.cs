using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MipSolver.Entities
{
    public class LoanInWarehouseCollection : List<LoanInWarehouse>
    {
        public LoanInWarehouseCollection()
        {
            int i = 0;
            var loans = new LoanCollection();
            var warehouses = new WarehouseCollection();

            foreach (var warehouse in warehouses)
            {
                foreach (var loan in loans)
                {
                    this.Add(new LoanInWarehouse() { Id = i, Loan = loan, Warehouse = warehouse });
                    i++;

                    //if ((loan.Id) % 3 == 0)
                    //{
                    //    if (warehouse.Id == 2 || warehouse.Id == 5 || warehouse.Id == 8 || warehouse.Id == 10 || warehouse.Id == 0)
                    //    {
                    //        this.Add(new LoanInWarehouse() { Id = i, Loan = loan, Warehouse = warehouse });
                    //        i++;
                    //    }
                    //}
                    //else if ((loan.Id) % 2 == 0)
                    //{
                    //    if (warehouse.Id == 3 || warehouse.Id == 7 || warehouse.Id == 9 || warehouse.Id == 10 || warehouse.Id == 0)
                    //    {
                    //        this.Add(new LoanInWarehouse() { Id = i, Loan = loan, Warehouse = warehouse });
                    //        i++;
                    //    }
                    //}
                    //else if ((loan.Id) % 5 == 0)
                    //{
                    //    if (warehouse.Id == 1 || warehouse.Id == 6 || warehouse.Id == 4 || warehouse.Id == 5 || warehouse.Id == 2)
                    //    {
                    //        this.Add(new LoanInWarehouse() { Id = i, Loan = loan, Warehouse = warehouse });
                    //        i++;
                    //    }
                    //}
                    //else if ((loan.Id) % 7 == 0)
                    //{
                    //    if (warehouse.Id == 2 || warehouse.Id == 1 || warehouse.Id == 7 || warehouse.Id == 4 || warehouse.Id == 9)
                    //    {
                    //        this.Add(new LoanInWarehouse() { Id = i, Loan = loan, Warehouse = warehouse });
                    //        i++;
                    //    }
                    //}
                    //else
                    //{
                    //    this.Add(new LoanInWarehouse() { Id = i, Loan = loan, Warehouse = warehouse });
                    //    i++;
                    //}




                }
            }
        }
    }
}
