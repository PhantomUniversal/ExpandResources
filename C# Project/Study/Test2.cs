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
    public partial class Test2 : Form
    {
        public Test2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Test3 test3Start = new Test3();
            test3Start.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("MELON");
            sw.Close();
            this.Visible = false;
            Test3 test3Start = new Test3();
            test3Start.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("MELON");
            sw.Close();
            this.Visible = false;
            Test3 test3Start = new Test3();
            test3Start.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("MELON");
            sw.Close();
            this.Visible = false;
            Test3 test3Start = new Test3();
            test3Start.Show();
        }
    }
}
