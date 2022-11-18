using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class form : Form
    {
        Cursor _cursor = new Cursor();
        Parser _parser = new Parser();
        ShapeFactory _shapeFactory = new ShapeFactory();

        public form()
        {
            InitializeComponent();
        }

        private void btnRunMultiline_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();

            try
            {
                List<Command> commands = _parser.ParseInput_MultiLine(txtCommandArea.Text);
                foreach (Command command in commands) { ExecuteCommand(g, command); }
            }
            catch (Exception exception)
            {
                lblError.Text = "Multi-line code warning: \n" + exception.Message;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();

            try
            {
                _cursor.Draw(g); // Draws a new cursor before every command in case it gets covered by another shape

                Command command = _parser.ParseInput_SingleLine(txtCommandLine.Text.Trim().ToLower());
                ExecuteCommand(g, command);

                // Resets all the labels if execute command works
                lblError.Text = "";
                txtCommandLine.Text = "";
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
            }
        }

        private void ExecuteCommand(Graphics g, Command command)
        {
            switch (command.ActionWord)
            {
                case Action.run:
                    {
                        List<Command> commands = _parser.ParseInput_MultiLine(txtCommandArea.Text);
                        foreach (Command c in commands) { ExecuteCommand(g, c); }
                        break;
                    }
                case Action.move:
                    {
                        _cursor.MoveTo(new Point(command.ActionValues[0], command.ActionValues[1]));
                        _cursor.Draw(g);
                        lblCoordinates.Text = "X:" + _cursor.Position.X + ", Y:" + _cursor.Position.Y;
                        break;
                    }
                case Action.fill:
                    {
                        if (command.ActionValues[0].Equals(1))
                        {
                            _cursor.Fill = true;
                            lblFillState.Text = "fill: enabled";
                        }
                        if (command.ActionValues[0].Equals(0))
                        {
                            _cursor.Fill = false;
                            lblFillState.Text = "fill: disabled";
                        }
                        break;
                    }
                case Action.reset:
                    {
                        _cursor.MoveTo(new Point(0, 0));
                        _cursor.ChangePenColor(_cursor.DefaultPenColor); // Resets cursor to default color (Red)
                        _cursor.ChangeFillState(_cursor.DefaultFill); // Resets cursor to default fill state (false ie; no fill)
                        _cursor.Draw(g);
                        lblCoordinates.Text = "X:" + _cursor.Position.X + ", Y:" + _cursor.Position.Y;
                        lblFillState.Text = "fill: disabled";
                        lblPenColor.Text = "pen: red";
                        break;
                    }
                case Action.clear:
                    {
                        //picboxCanvas.Refresh();
                        g.Clear(Color.White);
                        _cursor.Draw(g);
                        lblCoordinates.Text = "X:" + _cursor.Position.X + ", Y:" + _cursor.Position.Y;
                        lblFillState.Text = "fill: disabled";
                        break;
                    }
                case Action.pen:
                    {
                        if (command.ActionValues[0].Equals(1))
                        {
                            _cursor.PenColor = Color.Red;
                            lblPenColor.Text = "pen: red";
                        }
                        if (command.ActionValues[0].Equals(2))
                        {
                            _cursor.PenColor = Color.Green;
                            lblPenColor.Text = "pen: green";
                        }
                        if (command.ActionValues[0].Equals(3))
                        {
                            _cursor.PenColor = Color.Blue;
                            lblPenColor.Text = "pen: blue";
                        }
                        _cursor.Draw(g);
                        break;
                    }
                default:
                    {
                        Shape shape = _shapeFactory.CreateShape(command, _cursor.Position, _cursor.Fill, _cursor.PenColor);
                        shape.Draw(g);
                        _cursor.MoveTo(shape.Position);
                        _cursor.Draw(g);
                        lblCoordinates.Text = "X:" + _cursor.Position.X + ", Y:" + _cursor.Position.Y;
                        break;
                    }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var g = picboxCanvas.CreateGraphics();
            g.Clear(Color.White);
            //picboxCanvas.Refresh();
            _cursor.MoveTo(_cursor.DefaultPosition); // Resets cursor to default position (0,0)
            _cursor.ChangePenColor(_cursor.DefaultPenColor); // Resets cursor to default color (Red)
            _cursor.ChangeFillState(_cursor.DefaultFill); // Resets cursor to default fill state (false ie; no fill)
            _cursor.Draw(g);

            // Clearing all the labels in the WinForms window
            txtCommandLine.Text = "";
            lblError.Text = "";
            lblCoordinates.Text = "X:" + _cursor.Position.X + ", Y:" + _cursor.Position.Y;
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
            _cursor.Draw(g);
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Commands.txt";
            save.Filter = "Text File | *.txt";
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
            load.RestoreDirectory = true;

            if (load.ShowDialog() == DialogResult.OK)
            {
                txtCommandArea.Text = File.ReadAllText(load.FileName);
            }
        }

        private void aryanMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/aryanprince");
        }
    }
}
