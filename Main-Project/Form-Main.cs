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
            // WORKING CODE
            Graphics g = picboxCanvas.CreateGraphics();
            cursor.draw(g);

            string fullCommand = txtCommandLine.Text.ToLower();
            string[] splitCommand = fullCommand.Split(' ');
            lblError.Text = "";

            var validActions = Enum.GetNames(typeof(Action));
            // END OF WORKING CODE

            // TEST CODE
            Command command = parser.ParseInput(txtCommandLine.Text);
            // END OF TEST CODE

            if (validActions.Contains(splitCommand[0])) // Checks if first word in 'command line' is in the Actions Enum, if not it's an invalid command
            {
                //--- RECTANGLE ---
                if (command.ActionWord == Action.rectangle)
                {
                    shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor).draw(g);
                    cursor.draw(g);
                }

                //--- SQUARE ---
                if (command.ActionWord == Action.square)
                {
                    shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor).draw(g);
                    cursor.draw(g);
                }

                //--- CIRCLE ---
                if (command.ActionWord == Action.circle)
                {
                    shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor).draw(g);
                    cursor.draw(g);
                }

                // --- TRIANGLE ---
                if (command.ActionWord == Action.triangle)
                {
                    shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor).draw(g);
                    cursor.draw(g);
                }

                // --- DRAWTO COMMAND ---
                if (command.ActionWord == Action.drawto)
                {
                    shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor).draw(g); // Draws a line to a new position
                    cursor.moveTo(new Point(int.Parse(splitCommand[1]), int.Parse(splitCommand[2]))); // Updates the cursor position to the new position (at the end of the line drawn above)
                    cursor.draw(g); // Redraws the cursor at the updated cursor position
                    lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y; // Displays new cursor coordinates on the form
                }

                // --- MOVETO COMMMAND ---
                if (command.ActionWord == Action.move)
                {
                    cursor.moveTo(new Point(int.Parse(splitCommand[1]), int.Parse(splitCommand[2])));
                    cursor.draw(g);
                    lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                }

                //// --- RESET COMMMAND ---
                if (command.ActionWord == Action.reset)
                {
                    cursor.moveTo(new Point(0, 0));
                    cursor.draw(g);
                    lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                }

                // --- CLEAR COMMMAND ---
                if (command.ActionWord == Action.clear)
                {
                    picboxCanvas.Refresh(); // I believe doing Refresh() is better than g.Clear(Color.White);
                }

                // --- FILL COMMAND ---
                if (splitCommand[0] == "fill" && splitCommand[1] == "on")
                {
                    cursor.Fill = true;
                    lblFillState.Text = "fill: enabled";
                }
                if (splitCommand[0] == "fill" && splitCommand[1] == "off")
                {
                    cursor.Fill = false;
                    lblFillState.Text = "fill: disabled";
                }

                // --- PEN COLOUR COMMAND ---
                if (splitCommand[0] == "pen")
                {
                    if (splitCommand[1] == "red")
                    {
                        cursor.PenColor = Color.Red;
                        lblPenColor.Text = "pen colour: red";
                        cursor.draw(g);
                    }
                    if (splitCommand[1] == "green")
                    {
                        cursor.PenColor = Color.Green;
                        lblPenColor.Text = "pen colour: green";
                        cursor.draw(g);
                    }
                    if (splitCommand[1] == "blue")
                    {
                        cursor.PenColor = Color.Blue;
                        lblPenColor.Text = "pen colour: blue";
                        cursor.draw(g);
                    }
                    if (splitCommand[1] == "black")
                    {
                        cursor.PenColor = Color.Black;
                        lblPenColor.Text = "pen colour: black";
                        cursor.draw(g);
                    }
                    if (splitCommand[1] == "white")
                    {
                        cursor.PenColor = Color.White;
                        lblPenColor.Text = "pen colour: white";
                        cursor.draw(g);
                    }
                    if (splitCommand[1] == "gold")
                    {
                        cursor.PenColor = Color.Gold;
                        lblPenColor.Text = "pen colour: gold";
                        cursor.draw(g);
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
