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
            lblError.Text = "";

            //--- RECTANGLE ---
            try 
            {
                if (splitCommand[0] == "rectangle")
                {
                    Rectangle rect = new Rectangle(Color.Gold, p.X, p.Y, int.Parse(splitCommand[1]), int.Parse(splitCommand[2]));
                    Graphics g = picboxCanvas.CreateGraphics();
                    rect.draw(g);
                    //lblError.Text = ""; //Resets the error label since command works successfully
                }
            }
            catch (IndexOutOfRangeException)
            {
                lblError.Text = "ERROR!\nRequires at least 2 parameters \nFormat: rectangle <length> <height>\nExample: rectangle 100 150";
            }
            catch (FormatException)
            {
                lblError.Text = "ERROR!\nInteger parameters only \nFormat: rectangle <length> <height>\nExample: rectangle 100 150";
            }

            //--- SQUARE ---
            try
            {
                if (splitCommand[0] == "square")
                {
                    Rectangle square = new Rectangle(Color.Gold, p.X, p.Y, int.Parse(splitCommand[1]), int.Parse(splitCommand[1]));
                    Graphics g = picboxCanvas.CreateGraphics();
                    square.draw(g);
                    //lblError.Text = ""; //Resets the error label since command works successfully
                }
            }
            catch (IndexOutOfRangeException)
            {
                lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: rectangle <length> <height>\nExample: rectangle 100 150";
            }
            catch (FormatException)
            {
                lblError.Text = "ERROR!\nInteger parameters only \nFormat: square <side>\nExample: square 125";
            }

            //--- CIRCLE ---
            try
            {
                if (splitCommand[0] == "circle")
                {
                    Circle circ = new Circle(Color.Blue, p.X, p.Y, int.Parse(splitCommand[1]));
                    Graphics g = picboxCanvas.CreateGraphics();
                    circ.draw(g);
                    //lblError.Text = ""; //Resets the error label since command works successfully
                }
            }
            catch (IndexOutOfRangeException)
            {
                lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: circle <radius>\nExample: circle 100";
            }
            catch (FormatException)
            {
                lblError.Text = "ERROR!\nInteger parameters only \nFormat: circle <radius>\nExample: circle 100";
            } 
            
            // --- MOVETO COMMMAND ---
            if (splitCommand[0] == "moveto")
            {
                p.X = int.Parse(splitCommand[1]);
                p.Y = int.Parse(splitCommand[2]);
            }

            // --- RESET COMMMAND ---
            if (splitCommand[0] == "reset")
            {
                p.X = 0;
                p.Y = 0;
            }

            lblDebug.Text = "X:" + p.X + ", Y:" + p.Y;
            txtCommandLine.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            g.Clear(Color.White);
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
