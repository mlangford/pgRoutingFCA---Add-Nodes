using System;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace pgRoutingFCA
{
    public partial class Form0b : Form
    {
        public Form0b()
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
                    tbUser.Text = sr.ReadLine();
                    tbPwd.Text = sr.ReadLine();
                    tbHost.Text = sr.ReadLine();
                    tbPort.Text = sr.ReadLine();
                    tbDatabase.Text = sr.ReadLine();
                }
            }
            catch 
            {
                //just carry on with default settings
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            conString = "Server=" + tbHost.Text +
                                           "; Port=" + tbPort.Text +
                                           "; User Id=" + tbUser.Text +
                                           "; Password=" + tbPwd.Text +
                                           "; Database=" + tbDatabase.Text;
            try
            {
                using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                {
                    dbConnection.Open();
                    dbConnection.Close();
                    btGo_Click(sender, e);
                    //showlabel("connection OK", 3000);
                    btTest.Visible = false;
                    btGo.Visible = true;
                    btGo.Focus();
                }
            }
            catch
            {
                showlabel("connection failed: review settings", 4000);
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
                    sw.WriteLine(tbUser.Text);
                    sw.WriteLine(tbPwd.Text);
                    sw.WriteLine(tbHost.Text);
                    sw.WriteLine(tbPort.Text);
                    sw.WriteLine(tbDatabase.Text);
                }
            }
            catch
            {
                //just carry on
            }
            Form1a frm1a = new Form1a(conString);
            this.Hide();
            frm1a.Show();
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
