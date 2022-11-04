using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class form : Form
    {
        Cursor cursor = new Cursor();
        Parser parser = new Parser();
        ShapeFactory shapeFactory = new ShapeFactory();

        public form()
        {
            InitializeComponent();
        }

        private void btnRunMultiline_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            List<Command> commands = parser.ParseMultilineInput(txtCommandArea.Text);

            foreach (Command command in commands)
            {
                switch (command.ActionWord)
                {
                    case Action.move:
                        {
                            cursor.moveTo(new Point(command.ActionValues[0], command.ActionValues[1]));
                            cursor.draw(g);
                            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                            break;
                        }
                    case Action.fill:
                        {
                            if (command.ActionValues[0] == 1)
                            {
                                cursor.Fill = true;
                                lblFillState.Text = "fill: enabled";
                            }
                            if (command.ActionValues[0] == 0)
                            {
                                cursor.Fill = false;
                                lblFillState.Text = "fill: disabled";
                            }
                            break;
                        }
                    case Action.reset:
                        {
                            cursor.moveTo(new Point(0, 0));
                            cursor.draw(g);
                            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                            lblFillState.Text = "fill: disabled";
                            break;
                        }
                    case Action.clear:
                        {
                            picboxCanvas.Refresh();
                            cursor.draw(g);
                            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                            lblFillState.Text = "fill: disabled";
                            break;
                        }
                    case Action.pen:
                        {
                            if (command.ActionValues[0] == 1)
                            {
                                cursor.PenColor = Color.Red;
                                lblPenColor.Text = "pen: red";
                            }
                            if (command.ActionValues[0] == 2)
                            {
                                cursor.PenColor = Color.Green;
                                lblPenColor.Text = "pen: green";
                            }
                            if (command.ActionValues[0] == 3)
                            {
                                cursor.PenColor = Color.Blue;
                                lblPenColor.Text = "pen: blue";
                            }
                            cursor.draw(g);
                            break;
                        }
                    default:
                        {
                            Shape shape = shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor);
                            shape.draw(g);
                            cursor.moveTo(shape.Position);
                            cursor.draw(g);
                            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                            break;
                        }
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            cursor.draw(g);

            string fullCommand = txtCommandLine.Text.ToLower();
            string[] splitCommand = fullCommand.Split(' ');
            lblError.Text = "";

            var validActions = Enum.GetNames(typeof(Action));

            Command command = parser.ParseInput(txtCommandLine.Text);

            if (validActions.Contains(splitCommand[0])) // Checks if first word in 'command line' is in the Actions Enum, if not it's an invalid command
            {
                switch (command.ActionWord)
                {
                    case Action.move:
                        {
                            cursor.moveTo(new Point(command.ActionValues[0], command.ActionValues[1]));
                            cursor.draw(g);
                            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                            break;
                        }
                    case Action.fill:
                        {
                            if (command.ActionValues[0] == 1)
                            {
                                cursor.Fill = true;
                                lblFillState.Text = "fill: enabled";
                            }
                            if (command.ActionValues[0] == 0)
                            {
                                cursor.Fill = false;
                                lblFillState.Text = "fill: disabled";
                            }
                            break;
                        }
                    case Action.reset:
                        {
                            cursor.moveTo(new Point(0, 0));
                            cursor.draw(g);
                            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                            lblFillState.Text = "fill: disabled";
                            break;
                        }
                    case Action.clear:
                        {
                            picboxCanvas.Refresh();
                            cursor.draw(g);
                            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                            lblFillState.Text = "fill: disabled";
                            break;
                        }
                    case Action.pen:
                        {
                            if (command.ActionValues[0] == 1)
                            {
                                cursor.PenColor = Color.Red;
                                lblPenColor.Text = "pen: red";
                            }
                            if (command.ActionValues[0] == 2)
                            {
                                cursor.PenColor = Color.Green;
                                lblPenColor.Text = "pen: green";
                            }
                            if (command.ActionValues[0] == 3)
                            {
                                cursor.PenColor = Color.Blue;
                                lblPenColor.Text = "pen: blue";
                            }
                            cursor.draw(g);
                            break;
                        }
                    default:
                        {
                            Shape shape = shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor);
                            shape.draw(g);
                            cursor.moveTo(shape.Position);
                            cursor.draw(g);
                            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                            break;
                        }
                }
            }
            else // If the command is not part of the Action enum, it's considered invalid
            {
                lblError.Text = "Invalid command!";
            }

            txtCommandLine.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            picboxCanvas.Refresh(); // 
            cursor.moveTo(new Point(0, 0)); // Resets cursor position to 0,0

            // Clearing all the labels in the WinForms window
            txtCommandLine.Text = "";
            lblError.Text = "";
            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
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

        private void picboxCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            cursor.draw(g);
        }
    }
}
