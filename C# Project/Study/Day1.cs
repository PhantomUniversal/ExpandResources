using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen
{
    public partial class Day1 : Form
    {
        Image[] img = new Image[5];
        string[] text = new string[5];

        Timer timer = new Timer();
        int idx = 0;
        int idy = 0;
        bool isDrawButton = false;

        public int WIDTH = 0;
        public int HEIGHT = 0;

        public Day1()
        {
            InitializeComponent();
            this.Load += Day1_Load;
            this.Paint += Day1_Paint;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Day1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(img[idx++], 0, 0, ClientRectangle.Right, ClientRectangle.Bottom);
            if (idx == 5)
            {
                idx = 0;
                if (isDrawButton == false)
                {
                    isDrawButton = true;
                    DrawButton();
                }
            }
            e.Graphics.DrawString(text[idy++], new Font("궁서", 50), Brushes.Indigo, 
                (this.ClientRectangle.Width-400) / 2, (this.ClientRectangle.Height-100) / 2 );
            if (idy == 5)
                idy = 0;
        }

        private void Day1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                string path = "../../Resources/";
                path += (i + ".jpg");
                img[i] = Image.FromFile(path);
            }

            for (int j = 0; j < 5; j++)
            {
                string path2 = "../../Study/";
                path2 += (j + ".txt");
                text[j] = File.ReadAllText(path2);
            }
        }
        private void DrawButton()
        {
            Control[] BTN = new Control[1];
            FlowLayoutPanel flp = new FlowLayoutPanel();

          

            for (int udt = 0; udt < 1; udt++)
            {
                BTN[udt] = new Button();
                BTN[udt].Name = udt.ToString();
                BTN[udt].Parent = this;
                BTN[udt].Size = new Size(800, 500);                             

                int x = udt + 1;
                BTN[udt].Text = "TestStart" + x.ToString();

                WIDTH += 1000;
                HEIGHT += 1000;

                flp.Controls.Add(BTN[udt]);
                
            }
           
            BTN[0].Click += new EventHandler(btnclick_dyn);
            this.Controls.Add(flp);
            
            flp.Dock = DockStyle.Fill;
        }

        void btnclick_dyn(object sender, EventArgs e)
        {
            this.Visible = false;
            Test1 test1start = new Test1();
            test1start.Show();
        }

        private void Day1_Load_1(object sender, EventArgs e)
        {
            
            
        }
    }
}
