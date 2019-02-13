using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Group14_ATM
{
    class Program
    {
        static AccountData newAccount;
        static Account[] existingAccounts;
        static int activeATM;
        static int activeUser;
        static Thread ATMThread;
        static Boolean safeMode = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            newAccount = new AccountData();
            existingAccounts = newAccount.getAccounts();
            
            Application.Run(new Form1(existingAccounts));
        }

        public static void newATM() // create a new ATM
        {
            ATMThread = new Thread(ThreadProcess);
            ATMThread.Start();
        }

        public static Account[] getAccounts() // retrun the array of accounts
        {
            return existingAccounts;
        }

        public static void updateAccount(Account toBeUpdated, int index) // update the changed account after a transaction
        {
            existingAccounts[index] = toBeUpdated;
        }

        public static void updateMode(Boolean check) // update the program mode if checkbox is changed
        {
            safeMode = check;
        }

        public static Boolean getSafeMode() // get the safeMode variable
        {
            return safeMode;
        }

        public static void ThreadProcess()
        {
            Application.Run(new ATM(existingAccounts));
        }

        public static int getATMs()
        {
            return activeATM;
        }

        public static void setATMs(int activeATMs)
        {
            activeATM = activeATMs;
        }

        public static int getUsers()
        {
            return activeUser;
        }

        public static void setUsers(int activeUsers)
        {
            activeUser = activeUsers;
        }

        public static void incrementATM()
        {
            activeATM = activeATM + 1;
        }

        public static void decrementATM()
        {
            activeATM = activeATM - 1; 
        }

        public static void incrementUser()
        {
            activeUser = activeUser + 1;
        }

        public static void decrementUser()
        {
            activeUser = activeUser - 1;
        }
    }
}
