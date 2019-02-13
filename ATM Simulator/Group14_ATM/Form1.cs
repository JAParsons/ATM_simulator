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
    public partial class Form1 : Form
    {
        public Account[] accountsArray;
        //Program prog;
        int atmcount;
        
        public Form1(Account [] accountArray)
        {
            InitializeComponent();
            timer1.Start();
            accountsArray = accountArray;
            //prog = new Program();
            atmcount = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = accountsArray;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshGrid();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /*private void updateAccounts() // update the accounts after a transaction
        {
           accountsArray = Program.getAccounts();
            dataGridView1.DataSource = accountsArray;
            //refreshGrid();
        }*/

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool state = ((CheckBox)sender).Checked; // get checkbox state
            Program.updateMode(state); // update program state
            if (atmcount == 1) { textBox2.Text = "1"; }
            else if (atmcount == 2 && state) { textBox2.Text = "2"; }
            else { textBox2.Text = "1"; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {// allow for no more than 2 ATM's at once
            if (atmcount == 0)
            {
                Thread atm1 = new Thread(Program.newATM); // start new atm on new thread
                atm1.Start();
                atmcount++; // increase count
                textBox2.Text = "1";
            }
            else if (atmcount == 1)
            {
                Thread atm2 = new Thread(Program.newATM);
                atm2.Start();
                atmcount++;
                textBox2.Text = "2";
            }
            textBox1.Text = Convert.ToString(atmcount);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void refreshGrid()
        {
            dataGridView1.DataSource = accountsArray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshGrid();
            textBox1.Text = Program.getATMs().ToString();
            textBox2.Text = Program.getUsers().ToString();
            dataGridView1.DataSource = accountsArray;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
