
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
    public partial class Test1 : Form
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Test2 test3Start = new Test2();
            test3Start.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("APPLE");
            sw.Close();
            this.Visible = false;
            Test2 test2Start = new Test2();
            test2Start.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("APPLE");
            sw.Close();
            this.Visible = false;
            Test2 test2Start = new Test2();
            test2Start.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("APPLE");
            sw.Close();
            this.Visible = false;
            Test2 test2Start = new Test2();
            test2Start.Show();
        }
    }
}