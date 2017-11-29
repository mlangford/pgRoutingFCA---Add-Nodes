using System;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace pgRoutingFCA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string conString;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("lkg.txt"))
                {
                    textBox1.Text = sr.ReadLine();
                    textBox2.Text = sr.ReadLine();
                    textBox3.Text = sr.ReadLine();
                    textBox4.Text = sr.ReadLine();
                    textBox5.Text = sr.ReadLine();
                }
            }
            catch 
            {
                //just carry on with default settings
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            conString = "Server=" + textBox3.Text +
                                           "; Port=" + textBox4.Text +
                                           "; User Id=" + textBox1.Text +
                                           "; Password=" + textBox2.Text +
                                           "; Database=" + textBox5.Text;
            try
            {
                using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                {
                    dbConnection.Open();
                    dbConnection.Close();
                    showlabel("connection details OK", 3000);
                    btTest.Visible = false;
                    btGo.Visible = true;
                    btGo.Focus();
                }
            }
            catch
            {
                showlabel("connection failed ~ review settings", 4000);
                btGo.Enabled = false;
            }
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            try
            {
                //save Last Known Good details
                using (StreamWriter sw = new StreamWriter("lkg.txt", false))
                {
                    sw.WriteLine(textBox1.Text);
                    sw.WriteLine(textBox2.Text);
                    sw.WriteLine(textBox3.Text);
                    sw.WriteLine(textBox4.Text);
                    sw.WriteLine(textBox5.Text);
                }
            }
            catch
            {
                //just carry on
            }
            Form1b frm1b = new Form1b(conString);
            this.Hide();
            frm1b.Show();
        }

        //display a feedback label
        private void showlabel(string detail, int time)
        {
            lbFeedback.Text = detail;
            lbFeedback.Visible = true;
            timer1.Interval = time;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbFeedback.Visible = false;
            timer1.Stop();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            btTest.Visible = true;
            btGo.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
