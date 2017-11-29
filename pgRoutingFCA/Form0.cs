using System;
using System.Windows.Forms;

namespace pgRoutingFCA
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void Form0_Click(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1_Tick(null, null);
        }
    }
}
