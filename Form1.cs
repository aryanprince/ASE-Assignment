using System;
using System.Drawing;
using System.Linq;
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
            lblError.Text = "";
            var myCommands = Enum.GetNames(typeof(myCommands));

            if (myCommands.Contains(splitCommand[0])) //Checks if first word in 'command line' is in the myCommands Enum, if not it's an invalid command
            {
                //--- RECTANGLE ---
                try
                {
                    if (splitCommand[0] == "rectangle")
                    {
                        Rectangle rect = new Rectangle(Color.Gold, p.X, p.Y, int.Parse(splitCommand[1]), int.Parse(splitCommand[2]));
                        Graphics g = picboxCanvas.CreateGraphics();
                        rect.draw(g);
                    }
                }
                catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 2 parameters \nFormat: rectangle <length> <height>\nExample: rectangle 100 150"; }
                catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: rectangle <length> <height>\nExample: rectangle 100 150"; }

                //--- SQUARE ---
                try
                {
                    if (splitCommand[0] == "square")
                    {
                        Rectangle square = new Rectangle(Color.Gold, p.X, p.Y, int.Parse(splitCommand[1]), int.Parse(splitCommand[1]));
                        Graphics g = picboxCanvas.CreateGraphics();
                        square.draw(g);
                    }
                }
                catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: rectangle <length> <height>\nExample: rectangle 100 150"; }
                catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: square <side>\nExample: square 125"; }

                //--- CIRCLE ---
                try
                {
                    if (splitCommand[0] == "circle")
                    {
                        Circle circ = new Circle(Color.Blue, p.X, p.Y, int.Parse(splitCommand[1]));
                        Graphics g = picboxCanvas.CreateGraphics();
                        circ.draw(g);
                    }
                }
                catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: circle <radius>\nExample: circle 100"; }
                catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: circle <radius>\nExample: circle 100"; }

                // --- TRIANGLE ---
                try
                {
                    if (splitCommand[0] == "triangle")
                    {
                        Triangle tri = new Triangle(Color.Pink, p.X, p.Y, int.Parse(splitCommand[1]));
                        Graphics g = picboxCanvas.CreateGraphics();
                        tri.draw(g);
                    }
                }
                catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: triangle <side length>\nExample: triangle 150"; }
                catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: triangle <side length>\nExample: triangle 150"; }

                // --- MOVETO COMMMAND ---
                if (splitCommand[0] == "moveto")
                {
                    p.X = int.Parse(splitCommand[1]);
                    p.Y = int.Parse(splitCommand[2]);
                    lblCoordinates.Text = "X:" + p.X + ", Y:" + p.Y;
                }

                // --- RESET COMMMAND ---
                if (splitCommand[0] == "reset")
                {
                    p.X = 0;
                    p.Y = 0;
                }

                // --- CLEAR COMMMAND ---
                if (splitCommand[0] == "clear")
                {
                    Graphics g = picboxCanvas.CreateGraphics();
                    g.Clear(Color.White);
                }
            }
            else
            {
                lblError.Text = "Invalid command!";
            }
            txtCommandLine.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            g.Clear(Color.White);
            txtCommandLine.Text = "";
            lblError.Text = "";
        }

        private void txtCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) //Checks if Enter key is pressed
            {
                return;
            }
            btnRun.PerformClick(); 

            //Stops the 'ding' when pressing Enter
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }
}
