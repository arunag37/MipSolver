﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MipSolver.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double LoanAmount { get; set; }
        public double Cost { get; set; }
    }
}
