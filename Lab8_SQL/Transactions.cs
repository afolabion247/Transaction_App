using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    class Transactions
    {
        private int _transactionNumber;
        private DateTime _transactionDate;
        private decimal _transactionAmount;
        public Transactions()
        {

        }
        public Transactions(int transactionNumber,int accountNumber ,DateTime transactionDate, decimal transactionAmount)
        {
            TransactionNumber = transactionNumber;
            TransactionDate = transactionDate;
            TransactionAmount = transactionAmount;
            AccountNumber = accountNumber;
        }


        public int TransactionNumber
        {
            get
            {
                return _transactionNumber;
            }
            set
            {
                _transactionNumber = value;
            }
        }


      
        public int AccountNumber
        {
            get;


            set;

        }



        public DateTime TransactionDate
        {
            get
            {
                return _transactionDate;
            }
            set
            {
                _transactionDate = value;
            }
        }

        public decimal TransactionAmount
        {
            get
            {
                return _transactionAmount;
            }
            set
            {
                _transactionAmount = value;
            }

       }
            public override string ToString() => $"{TransactionNumber}  {AccountNumber}   {TransactionAmount}  {TransactionDate}";

    }
}
