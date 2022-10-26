using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class form : Form
    {
        Point p = new Point();

        public form()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string fullCommand = txtCommandLine.Text;
            string[] splitCommand = fullCommand.Split(' ');

            if (splitCommand[0] == "rectangle")
            {
                Rectangle rect = new Rectangle(Color.Gold, p.X, p.Y, int.Parse(splitCommand[1]), int.Parse(splitCommand[2]));
                Graphics g = picboxCanvas.CreateGraphics();
                rect.draw(g);
            }

            if (splitCommand[0] == "square")
            {
                Rectangle square = new Rectangle(Color.Gold, p.X, p.Y, int.Parse(splitCommand[1]), int.Parse(splitCommand[1]));
                Graphics g = picboxCanvas.CreateGraphics();
                square.draw(g);
            }

            if (splitCommand[0] == "circle")
            {
                Circle circ = new Circle(Color.Blue, p.X, p.Y, int.Parse(splitCommand[1]));
                Graphics g = picboxCanvas.CreateGraphics();
                circ.draw(g);
            }

            if (splitCommand[0] == "moveto")
            {
                p.X = int.Parse(splitCommand[1]);
                p.Y = int.Parse(splitCommand[2]);
            }

            lblDebug.Text = "X:" + p.X + ", Y:" + p.Y;
            txtCommandLine.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            g.Clear(SystemColors.Control);
        }

        private void txtCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            btnRun.PerformClick();
        }
    }
}
