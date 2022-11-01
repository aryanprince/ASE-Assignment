using System;
using System.Drawing;
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
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            lblError.Text = "";

            Command command = parser.ParseInput(txtCommandLine.Text);

            switch (command.ActionWord)
            {
                case Action.rectangle:
                    {
                        Rectangle rectangle = new Rectangle(cursor.Position, command.ActionValues[0], command.ActionValues[1]);
                        rectangle.draw(g);
                        break;
                    }

                case Action.circle:
                    {
                        Circle circle = new Circle(cursor.Position, command.ActionValues[0]);
                        circle.draw(g);
                        break;
                    }
                case Action.move:
                    {
                        cursor.moveTo(new Point(command.ActionValues[0], command.ActionValues[1]));
                        lblCoordinates.Text = "X: " + command.ActionValues[0] + " Y: " + command.ActionValues[1];
                        break;
                    }
                default:
                    {
                        lblError.Text = "Invalid command";
                        break;
                    }
            }
            cursor.draw(g);

            //catch (IndexOutOfRangeException ex) { lblError.Text = "ERROR!\n" + ex.Message; }
            //catch (FormatException ex) { lblError.Text = "ERROR!\n" + ex.Message; }
            //catch (ArgumentException ex) { lblError.Text = "ERROR!\n" + ex.Message; }
            //catch (OverflowException ex) { lblError.Text = "ERROR!\n" + ex.Message; }
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
