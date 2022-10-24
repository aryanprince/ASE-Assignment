using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string fullCommand = txtCommandLine.Text;
            string[] splitCommand = fullCommand.Split(' ');

            Point p = new Point();

            if (splitCommand[0] == "r")
            {
                Rectangle rect = new Rectangle(Color.Gold, p.X, p.Y, 100, 150);
                Graphics g = picboxCanvas.CreateGraphics();
                rect.draw(g);
                Console.WriteLine(rect.ToString());
                lblDebug.Text = rect.ToString();
            }

            if (splitCommand[0] == "c")
            {
                Circle circ = new Circle(Color.Blue, p.X, p.Y, 100);
                Graphics g = picboxCanvas.CreateGraphics();
                circ.draw(g);
                Console.WriteLine(circ.ToString());
                lblDebug.Text = circ.ToString();
            }

            if (splitCommand[0] == "moveto")
            {
                p.X = int.Parse(splitCommand[1]);
                p.Y = int.Parse(splitCommand[2]);
                Console.WriteLine(p.X);
                Console.WriteLine(p.Y);
                Console.WriteLine(int.Parse(splitCommand[1]));
                Console.WriteLine(int.Parse(splitCommand[2]));

            }

            txtCommandLine.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            g.Clear(SystemColors.Control);
        }
    }
}
