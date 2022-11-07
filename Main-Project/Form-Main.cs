using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            List<Command> commands = parser.ParseInput_MultiLine(txtCommandArea.Text);

            foreach (Command command in commands) { ExecuteCommand(g, command); }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            cursor.Draw(g);

            string fullCommand = txtCommandLine.Text.ToLower();
            string[] splitCommand = fullCommand.Split(' ');
            lblError.Text = "";

            var validActions = Enum.GetNames(typeof(Action));

            Command command = parser.ParseInput_SingleLine(txtCommandLine.Text);

            if (!validActions.Contains(splitCommand[0])) // Checks if first word in 'command line' is in the Actions Enum, if not it's an invalid command
                lblError.Text = "Invalid command!";

            ExecuteCommand(g, command);

            txtCommandLine.Text = "";
        }

        private void ExecuteCommand(Graphics g, Command command)
        {
            switch (command.ActionWord)
            {
                case Action.move:
                    {
                        cursor.MoveTo(new Point(command.ActionValues[0], command.ActionValues[1]));
                        cursor.Draw(g);
                        lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                        break;
                    }
                case Action.fill:
                    {
                        if (command.ActionValues[0].Equals(1))
                        {
                            cursor.Fill = true;
                            lblFillState.Text = "fill: enabled";
                        }
                        if (command.ActionValues[0].Equals(0))
                        {
                            cursor.Fill = false;
                            lblFillState.Text = "fill: disabled";
                        }
                        break;
                    }
                case Action.reset:
                    {
                        cursor.MoveTo(new Point(0, 0));
                        cursor.ChangePenColor(cursor.DefaultPenColor); // Resets cursor to default color (Red)
                        cursor.ChangeFillState(cursor.DefaultFill); // Resets cursor to default fill state (false ie; no fill)
                        cursor.Draw(g);
                        lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                        lblFillState.Text = "fill: disabled";
                        lblPenColor.Text = "pen: red";
                        break;
                    }
                case Action.clear:
                    {
                        //picboxCanvas.Refresh();
                        g.Clear(Color.White);
                        cursor.Draw(g);
                        lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                        lblFillState.Text = "fill: disabled";
                        break;
                    }
                case Action.pen:
                    {
                        if (command.ActionValues[0].Equals(1))
                        {
                            cursor.PenColor = Color.Red;
                            lblPenColor.Text = "pen: red";
                        }
                        if (command.ActionValues[0].Equals(2))
                        {
                            cursor.PenColor = Color.Green;
                            lblPenColor.Text = "pen: green";
                        }
                        if (command.ActionValues[0].Equals(3))
                        {
                            cursor.PenColor = Color.Blue;
                            lblPenColor.Text = "pen: blue";
                        }
                        cursor.Draw(g);
                        break;
                    }
                default:
                    {
                        Shape shape = shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor, lblError);
                        shape.Draw(g);
                        cursor.MoveTo(shape.Position);
                        cursor.Draw(g);
                        lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
                        break;
                    }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var g = picboxCanvas.CreateGraphics();
            g.Clear(Color.White);
            //picboxCanvas.Refresh();
            cursor.MoveTo(cursor.DefaultPosition); // Resets cursor to default position (0,0)
            cursor.ChangePenColor(cursor.DefaultPenColor); // Resets cursor to default color (Red)
            cursor.ChangeFillState(cursor.DefaultFill); // Resets cursor to default fill state (false ie; no fill)
            cursor.Draw(g);

            // Clearing all the labels in the WinForms window
            txtCommandLine.Text = "";
            lblError.Text = "";
            lblCoordinates.Text = "X:" + cursor.Position.X + ", Y:" + cursor.Position.Y;
            lblFillState.Text = "fill: disabled";
            lblPenColor.Text = "pen: red";
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
            cursor.Draw(g);
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Commands.txt";
            save.Filter = "Text File | *.txt";
            save.InitialDirectory = "C:\\";
            save.RestoreDirectory = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, txtCommandArea.Text);
            }
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "Text File | *.txt";
            load.InitialDirectory = "C:\\";
            load.RestoreDirectory = true;

            if (load.ShowDialog() == DialogResult.OK)
            {
                txtCommandArea.Text = File.ReadAllText(load.FileName);
            }
        }
    }
}
