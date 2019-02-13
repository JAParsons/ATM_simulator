using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Group14_ATM
{
    public partial class ATM : Form
    {
        string input = "";
        string accNum = "";
        string pin = "";
        Account[] accounts;
        int numberOfAccounts = 3;
        int openedAcc = 0; // account that ATM has accessed
        Boolean authorised;
        Boolean back = false; // flag for returning to menu
        Boolean requestWithdraw = false;

        public ATM(Account[] existingAccounts)
        {
            InitializeComponent();
            accounts = existingAccounts;
            authorised = false;
        }

        private void button11_Click(object sender, EventArgs e) // cancel button
        {
            input = "";
            accNum = "";
            pin = "";
            authorised = false;
            requestWithdraw = false;
            textBox1.Text = "Please enter account number:";
            textBox1.Text += Environment.NewLine; // add new lines
            textBox1.Text += Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input = input + "1";
            textBox1.Text = textBox1.Text + "*";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            input = input + "2";
            textBox1.Text = textBox1.Text + "*";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            input = input + "3";
            textBox1.Text = textBox1.Text + "*";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            input = input + "4";
            textBox1.Text = textBox1.Text + "*";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            input = input + "5";
            textBox1.Text = textBox1.Text + "*";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            input = input + "6";
            textBox1.Text = textBox1.Text + "*";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            input = input + "7";
            textBox1.Text = textBox1.Text + "*";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            input = input + "8";
            textBox1.Text = textBox1.Text + "*";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            input = input + "9";
            textBox1.Text = textBox1.Text + "*";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            input = input + "0";
            textBox1.Text = textBox1.Text + "*";
        }

        private void button12_Click(object sender, EventArgs e) //  Clear button
        {
            if (!back)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.LastIndexOf(Environment.NewLine)); // delete last line
                textBox1.Text += Environment.NewLine; // add new line
                pin = "";
            }
            else
            {
                back = false; // reset flag
                displayOptions(); // back to sub menu
            }
        }

        private void displayOptions()
        {
            input = "";
            textBox1.Text = "Welcome " + accNum;
            textBox1.Text += Environment.NewLine; // add new line
            textBox1.Text += "Please choose from the following menu items:";
            textBox1.Text += Environment.NewLine; // add new line
            textBox1.Text += "Press 1 to withdraw";
            textBox1.Text += Environment.NewLine; // add new line
            textBox1.Text += "Press 2 to check balance";
            textBox1.Text += Environment.NewLine; // add new line
            textBox1.Text += "Press 3 to return card";
            textBox1.Text += Environment.NewLine; // add new line
        }

        private void displayAmounts()
        {
            input = "";
            textBox1.Text = "";
            textBox1.Text += "How much would you like to withdraw?";
            textBox1.Text += Environment.NewLine; // add new line
            textBox1.Text += "Press 1 to withdraw £10";
            textBox1.Text += Environment.NewLine; // add new line
            textBox1.Text += "Press 2 to withdraw £20";
            textBox1.Text += Environment.NewLine; // add new line
            textBox1.Text += "Press 3 to withdraw £40";
            textBox1.Text += Environment.NewLine; // add new line
            textBox1.Text += "Press 4 to withdraw £100";
            textBox1.Text += Environment.NewLine; // add new line
            textBox1.Text += "Press 5 to withdraw £500";
            textBox1.Text += Environment.NewLine; // add new line
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!authorised) // if not already logged in
            {

                if (accNum == "") // if account number is blank then the input is the account number
                {
                    accNum = input;
                    textBox1.Text = "Please enter pin number:";
                    textBox1.Text += Environment.NewLine; // add new lines
                    textBox1.Text += Environment.NewLine;
                }
                else // else the input is the pin
                {
                    pin = input;
                }
                input = "";

                // CHECK IF VALID ELSE DISPLAY A MESSAGE 
                if (accNum != "" && pin != "")
                {
                    for (int i = 0; i < numberOfAccounts; i++) // for every account
                    {
                        if (accounts[i].checkAcc(Convert.ToInt32(accNum))) // check the account num
                        {
                            if (accounts[i].checkPin(Convert.ToInt32(pin))) // check the pin
                            {
                                authorised = true; // details match 
                                openedAcc = i; // make note of the opened account 
                                i = numberOfAccounts;
                            }
                        }
                    }

                    if (!authorised) // if incorrect details
                    {
                        input = "";
                        accNum = "";
                        pin = "";
                        textBox1.Text = "Incorrect details. Please try again";
                        textBox1.Text += Environment.NewLine;
                        textBox1.Text += "Please enter account number:";
                        textBox1.Text += Environment.NewLine; // add new lines
                        textBox1.Text += Environment.NewLine;
                    }
                    else { displayOptions(); }
                }
            }
            else if (requestWithdraw)
            {
                Boolean success = false;
                requestWithdraw = false;
                if (input == "1") // if £10
                {
                    success = accounts[openedAcc].decrementBalance(10);
                }
                else if (input == "2") // if £20
                {
                    success = accounts[openedAcc].decrementBalance(20);
                }
                else if (input == "3") // if £40
                {
                    success = accounts[openedAcc].decrementBalance(40);
                }
                else if (input == "4") // if £100
                {
                    success = accounts[openedAcc].decrementBalance(100);
                }
                else if (input == "5") // if £500
                {
                    success = accounts[openedAcc].decrementBalance(500);
                }
                
                if (success) // if transaction is successful
                {
                    Program.updateAccount(accounts[openedAcc], openedAcc); // update the programs's accounts
                    textBox1.Text = "Please take your money";
                    textBox1.Text += Environment.NewLine; // add new line
                    textBox1.Text += "Please press 'Clear' to return:";
                    back = true; // set go back flag
                }
                else
                {
                    textBox1.Text = "Insufficient funds";
                    textBox1.Text += Environment.NewLine; // add new line
                    textBox1.Text += "Please press 'Clear' to return:";
                    back = true; // set go back flag
                }
            }
            else
            {
                if (input == "1") // if withdraw
                {
                    requestWithdraw = true;
                    displayAmounts();
                }
                else if (input == "2") // if check balance
                {
                    int balance = accounts[openedAcc].getBalance();
                    textBox1.Text = "Account balance = £" + balance;
                    textBox1.Text += Environment.NewLine; // add new line
                    textBox1.Text += "Please press 'Clear' to return:";
                    back = true; // set go back flag
                }
                else if (input == "3") // if return card
                {
                    button11_Click(sender, e); // return to main menu
                }
            }


        }

        private void ATM_Load(object sender, EventArgs e)
        {

        }

    }
}
