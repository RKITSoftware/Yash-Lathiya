using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.BL
{
    public abstract class Wallet
    {
        public abstract decimal CurrentBalance(int r01f01);

        public abstract decimal TotalExpense(int r01f01);

        public abstract decimal TotalCredit(int r01f01);
    }
}