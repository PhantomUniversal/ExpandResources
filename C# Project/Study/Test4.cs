using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen
{
    public partial class Test4 : Form
    {
        public Test4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("KIWI");
            sw.Close();
            this.Visible = false;
            Test5 test5Start = new Test5();
            test5Start.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Test5 test5Start = new Test5();
            test5Start.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("KIWI");
            sw.Close();
            this.Visible = false;
            Test5 test5Start = new Test5();
            test5Start.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("KIWI");
            sw.Close();
            this.Visible = false;
            Test5 test5Start = new Test5();
            test5Start.Show();
        }
    }
}