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
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            this.ClientSize = new Size(1200, 800);
        }

        private void 시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameStart gameStart = new GameStart();
            gameStart.MdiParent = this;
            gameStart.Show();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit exit = new Exit();
            exit.Show();
        }

        private void 점수판ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            scoreBoard.MdiParent = this;
            scoreBoard.Show();
        }
    }
}
