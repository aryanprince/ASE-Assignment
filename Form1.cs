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

            if (splitCommand[0] == "rect")
            {
                Rectangle rect = new Rectangle(Color.Gold, 40, 50, 100, 150);
                Graphics g = picboxCanvas.CreateGraphics();
                rect.draw(g);
                Console.WriteLine(rect.ToString());
                lblDebug.Text = rect.ToString();
            }

            if (splitCommand[0] == "circ")
            {
                Circle circ = new Circle(Color.Blue, 40, 50, 100);
                Graphics g = picboxCanvas.CreateGraphics();
                circ.draw(g);
                Console.WriteLine(circ.ToString());
                lblDebug.Text = circ.ToString();
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
