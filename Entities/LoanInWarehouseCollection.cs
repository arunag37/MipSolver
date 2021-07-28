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
                    this.Add(new LoanInWarehouse() { Id = i, Loan= loan ,Warehouse= warehouse });
                    i++;
                }
            }
        }
    }
}
