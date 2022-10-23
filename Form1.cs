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
                Rectangle rect1 = new Rectangle(0, 0, System.Convert.ToInt32(splitCommand[1]), System.Convert.ToInt32(splitCommand[2]));
                Graphics g = picboxCanvas.CreateGraphics();
                Pen myBlackPen = new Pen(Color.Black, 3);
                g.DrawRectangle(myBlackPen, rect1);
                myBlackPen.Dispose();
            }

            if (splitCommand[0] == "circle")
            {
                //Graphics g = picboxCanvas.CreateGraphics();
                //Pen myBlackPen = new Pen(Color.Black, 3);
                //g.DrawEllipse(myBlackPen, 0, 0, System.Convert.ToInt32(splitCommand[1]), System.Convert.ToInt32(splitCommand[1]));
                //myBlackPen.Dispose();

                Circle circ = new Circle(Color.Blue, 40, 50, 100);
                Graphics g = picboxCanvas.CreateGraphics();
                circ.draw(g);
                Console.WriteLine(circ.ToString());
                lblDebug.Text = circ.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            g.Clear(SystemColors.Control);
        }
    }
}
