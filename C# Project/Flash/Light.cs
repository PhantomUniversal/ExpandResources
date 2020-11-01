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
    public partial class Light : Form
    {
        Timer timer = new Timer();
        bool isBlinking = false;
        string[] words = File.ReadAllLines(@"../../testEN.txt");
        int cnt = 0;
        int Idx = 0;

        public Light()
        {
            InitializeComponent();
            this.Load += Light_Load;      
            this.Paint += Light_Paint;

            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            

            if (isBlinking == true)
            {
                lbBlinking.Visible = false;
                isBlinking = false;
            }
            else
            {
                isBlinking = true;
                lbBlinking.Visible = true;
            }
            cnt++;
            if (cnt == 5)
            {
                cnt = 0;
                Idx++;
                if (Idx > 4)
                    Idx = 0;
            }

            lbBlinking.Text = words[Idx];
        }

        private void Light_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Font font = new Font("Consolas", 34);

        }

        private void Light_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            lbBlinking.Text = "Start!";            
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            string str = tbWord.Text;
            tbView.Text += str;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbView.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit exit = new Exit();
            exit.Show();
        }

        private void tbWord_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        string str = tbWord.Text;
                        tbWord.Clear();
                        tbView.Text += str;
                        tbView.Text += "\r\n";
                    }
                    break;
            }
        }
    }
}