using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen
{
    public partial class Exit : Form
    {
        public Exit()
        {
            InitializeComponent();
            this.Load += Exit_Load;
            this.KeyDown += Exit_KeyDown;
            this.Paint += Exit_Paint;
        }

        private void Exit_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("휴먼편지체", 30, FontStyle.Bold);
            g.DrawString("Press Enter!!!", font, Brushes.White, 330, 50);
        }

        private void Exit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (MessageBox.Show("진짜 끌꺼야?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                    Close();
            }
        }

        private void Exit_Load(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = "../../ExitBGM.wav";
            sp.Play();
        }
    }
}