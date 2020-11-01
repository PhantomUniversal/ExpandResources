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
    public partial class WrongNote : Form
    {
        public WrongNote()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] buf = new char[1024];
            int ret = 0;
            StreamReader sr = new StreamReader("../../testEN.txt");
            tbMemo.Clear();
            while (true)
            {
                // ret은 실제 읽어들인 크기
                ret = sr.Read(buf, 0, buf.Length);
                tbMemo.Text += new string(buf, 0, ret);
                if (ret < 1024)
                    break;
            }
            sr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbMemo.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 form1Start = new Form1();
            form1Start.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Exit exit = new Exit();
            exit.Show();
        }
    }
}
