using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_App
{
    class Account
    {
        
        //private DateTime BalanceDate;
        private decimal _balance;

        public Account(int accountNumber,string firstName,string lastName,string email,string phoneNum)
        {

          this.AccountNumber = accountNumber;
          this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phoneNum;
           
        }

        public Account()
        {

        }
        public int AccountNumber
        {
            get;
            

            set;
           
        }

        public string FirstName
        {
            get;


            set;
        }

        public string LastName
        {
            get;


            set;
        }

        public string Email
        {
            get;


            set;
        }


        public string Phone
        {
            get;


            set;
        }

        public override string ToString() => $"{AccountNumber} {FirstName} {LastName} {Email} {Phone}";
    }
}
