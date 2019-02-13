using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Group14_ATM
{
    /*
     *   The Account class encapusulates all features of a simple bank account
     */
    public class Account
    {
        //The attributes for the account
        private Object thisLock = new object();
        private int accBalance;
        private int accPin;
        private int accNum;
        private bool threadSafe;

        //A constructor that takes initial values of each of the atrributes
        public Account(int balance, int pin, int accountNum)
        {
            this.accBalance = balance;
            this.accPin = pin;
            this.accNum = accountNum;
            this.threadSafe = false;
        }
        
        //getter and setter for balance
        public int balance
        {
            get {
                return accBalance;
            }
            set {
                accBalance = value;
            }
        }

        public int getBalance() { return accBalance; }
        public void setBalance(int value) { accBalance = value; }

        //getter and setter for pin
        public int pin
        {
            get
            {
                return accPin;
            }
            set
            {
                accPin = value;
            }
        }

        //getter and setter for accountNum
        public int accountNum
        {
            get
            {
                return accNum;
            }
            set
            {
                accNum = value;
            }
        }

        public void setThreadSafe(bool dataSafe)
        {
            threadSafe = dataSafe;
        }

        public bool getThreadSafe()
        {
            return threadSafe;
        }

        /*
        *   This funciton allows us to decrement the balance of an account
        *   it perfomes a simple check to ensure the balance is greater tha
        *   the amount being debeted
        *   
        *   returns:
        *   true if the transactions if possible
        *   false if there are insufficent funds in the account
        */
        public Boolean decrementBalance(int amount)
        {
            threadSafe = Program.getSafeMode(); // check if in safe mode
            //carry out transaction if there is equal or more funds available
            if (this.balance >= amount)
            {
                //if the thread safe option has been enabled
                if (threadSafe)
                {
                    //lock code so only one thread can access it at a time
                    lock (thisLock)
                    {
                        //temporarily store balance
                        int tempBalance = balance;
                        Thread.Sleep(1500);

                        //reduce the amount requested from the temporary balance
                        tempBalance = tempBalance - amount;
                        Thread.Sleep(1500);

                        //update balance
                        balance = tempBalance;
                    }
                }
                else
                {
                    //temporarily store balance
                    int tempBalance = balance;
                    Thread.Sleep(1500);

                    //reduce amount from temporary balance and wait
                    tempBalance = tempBalance - amount;
                    Thread.Sleep(1500);

                    //update balance with the correct balance
                    balance = tempBalance;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
        * This funciton check the account pin against the argument passed to it
        *
        * returns:
        * true if they match
        * false if they do not
        */
        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkAcc(int accEntered)
        {
            if (accEntered == accNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}