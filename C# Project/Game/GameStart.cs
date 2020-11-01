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
    public partial class GameStart : Form
    {
        public class Voca
        {
            public string KR { get; set; }
            public string EN { get; set; }
            public int VocaX { get; set; }
            public int VocaY { get; set; }
            public Voca(string KR, string EN, int VocaX, int VocaY)
            {
                this.KR = KR;
                this.EN = EN;
                this.VocaX = VocaX;
                this.VocaY = VocaY;
            }
        }

        int MovingY = 0;
        int MOVE_VAL = 20;
        //int cnt = 0;
        int Score = 0;
        string str;

        Timer timer = new Timer();
        Random r = new Random();

        List<Voca> VocaList = new List<Voca>();

        public GameStart()
        {
            InitializeComponent();
            this.Paint += GameStart_Paint;
            this.Load += GameStart_Load;
            timer.Interval = 1200;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.ClientSize = new Size(1000, 600);
        }

        private void GameStart_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void tbAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        str = tbAnswer.Text;
                        tbAnswer.Clear();
                    }
                    break;
                case Keys.Escape:
                    {
                        Close();
                    }
                    break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MovingY += MOVE_VAL;
            string path = "../../testEN.txt";
            string[] line = System.IO.File.ReadAllLines(path);

            string path1 = "../../testEN.txt";
            string[] line1 = System.IO.File.ReadAllLines(path1);

            int sel = r.Next(line.Length);

            VocaList.Add(new Voca(line[sel], line1[sel], r.Next(50, 650), -2 * MovingY));

            Invalidate();
        }

        private void GameStart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("휴먼편지체", 30, FontStyle.Bold);

            for(int i = 0; i<VocaList.Count; i++)
            {
                g.DrawString(VocaList[i].KR, font, Brushes.White, VocaList[i].VocaX, VocaList[i].VocaY + MovingY);

                if (str == VocaList[i].EN)
                {
                    VocaList.RemoveAt(i);
                    Score += 10;
                }
                else if (VocaList[i].VocaY + MovingY == 300)
                {
                    VocaList.RemoveAt(i);
                    Score -= 20;
                }
                g.DrawString("Score : " + Score, font, Brushes.White, 770, 30);
            }
        }
    }
}
