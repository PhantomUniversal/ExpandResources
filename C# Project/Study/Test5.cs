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
    public partial class Test5 : Form
    {
        public Test5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("LIME");
            sw.Close();
            this.Visible = false;
            Test6 test6Start = new Test6();
            test6Start.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("LIME");
            sw.Close();
            this.Visible = false;
            Test6 test6Start = new Test6();
            test6Start.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Test6 test6Start = new Test6();
            test6Start.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../testEN.txt", true);
            sw.WriteLine("LIME");
            sw.Close();
            this.Visible = false;
            Test6 test6Start = new Test6();
            test6Start.Show();
        }
    }
}
