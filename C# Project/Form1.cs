using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.ShowDialog();
        }

        private void btnLight_Click(object sender, EventArgs e)
        {
            MessageBox.Show("깜빡이 학습을 시작합니다");

            Light light = new Light();
            light.Show();
        }

        private void btnStudy_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Day1 test1start = new Day1();
            test1start.Show();
        }

        private void btnNG_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            WrongNote wrongnotestart = new WrongNote();
            wrongnotestart.Show();
        }
    }
}
