using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class form : Form
    {
        Cursor cursor = new Cursor();
        Parser parser = new Parser();
        public form()
        {
            InitializeComponent();

            //--- CURSOR BITMAP CODE ---
            //Bitmap cursor = new Bitmap(900, 500);
            //cursor.MakeTransparent();
            //Graphics cursorGraphics = Graphics.FromImage(cursor);
            //cursorGraphics.FillRectangle(Brushes.Red, 0, 0, 5, 5);
            //picboxCanvas.Image = cursor;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            parser.ParseInput(txtCommandLine.Text);
            
            string fullCommand = txtCommandLine.Text.ToLower();
            string[] splitCommand = fullCommand.Split(' ');
            lblError.Text = "";
            var myCommands = Enum.GetNames(typeof(ValidCommands));

            if (myCommands.Contains(splitCommand[0])) //Checks if first word in 'command line' is in the myCommands Enum, if not it's an invalid command
            {
                //--- RECTANGLE ---
                try
                {
                    if (splitCommand[0] == "rectangle")
                    {
                        Rectangle rect = new Rectangle(cursor.Position, int.Parse(splitCommand[1]), int.Parse(splitCommand[2]));
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
                        Rectangle square = new Rectangle(cursor.Position, int.Parse(splitCommand[1]), int.Parse(splitCommand[1]));
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
                        Circle circ = new Circle(cursor.Position, int.Parse(splitCommand[1]));
                        Graphics g = picboxCanvas.CreateGraphics();
                        circ.draw(g);
                    }
                }
                catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: circle <radius>\nExample: circle 100"; }
                catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: circle <radius>\nExample: circle 100"; }

                //// --- TRIANGLE ---
                //try
                //{
                //    if (splitCommand[0] == "triangle")
                //    {
                //        Triangle tri = new Triangle(Color.Pink, cursor.Position, int.Parse(splitCommand[1]));
                //        Graphics g = picboxCanvas.CreateGraphics();
                //        tri.draw(g);
                //    }
                //}
                //catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: triangle <side length>\nExample: triangle 150"; }
                //catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: triangle <side length>\nExample: triangle 150"; }

                // --- MOVETO COMMMAND ---
                if (splitCommand[0] == "move")
                {
                    //cursor.X = int.Parse(splitCommand[1]);
                    //cursor.Y = int.Parse(splitCommand[2]);
                    cursor.moveTo(new Point(int.Parse(splitCommand[1]), int.Parse(splitCommand[2])));
                    lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                }

                //// --- RESET COMMMAND ---
                //if (splitCommand[0] == "reset")
                //{
                //    cursor.X = 0;
                //    cursor.Y = 0;
                //}

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
