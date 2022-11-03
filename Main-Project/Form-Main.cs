﻿using System;
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
                try
                {
                    if (command.ActionWord == Action.rectangle)
                    {
                        shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor).draw(g);
                        cursor.draw(g);
                    }
                }
                catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 2 parameters \nFormat: rectangle <length> <height>\nExample: rectangle 100 150"; }
                catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: rectangle <length> <height>\nExample: rectangle 100 150"; }

                //--- SQUARE ---
                try
                {
                    if (command.ActionWord == Action.square)
                    {
                        shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor).draw(g);
                        cursor.draw(g);
                    }
                }
                catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: rectangle <length> <height>\nExample: rectangle 100 150"; }
                catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: square <side>\nExample: square 125"; }

                //--- CIRCLE ---
                try
                {
                    if (command.ActionWord == Action.circle)
                    {
                        shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor).draw(g);
                        cursor.draw(g);
                    }
                }
                catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: circle <radius>\nExample: circle 100"; }
                catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: circle <radius>\nExample: circle 100"; }

                // --- TRIANGLE ---
                try
                {
                    if (command.ActionWord == Action.triangle)
                    {
                        shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor).draw(g);
                        cursor.draw(g);
                    }
                }
                catch (IndexOutOfRangeException) { lblError.Text = "ERROR!\nRequires at least 1 parameter \nFormat: triangle <side length>\nExample: triangle 150"; }
                catch (FormatException) { lblError.Text = "ERROR!\nInteger parameters only \nFormat: triangle <side length>\nExample: triangle 150"; }

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
