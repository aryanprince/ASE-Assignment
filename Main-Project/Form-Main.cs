using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class frmMainForm : Form
    {
        // Instances of the classes that are used in the form
        private readonly Cursor _cursor = new Cursor();
        private readonly Parser _parser = new Parser();
        private readonly ShapeFactory _shapeFactory = new ShapeFactory();

        // Localized strings for WinForms controls
        private const string PenColorBlueText = "pen color: blue";
        private const string PenColorGreenText = "pen color: green";
        private const string PenColorRedText = "pen color: red";
        private const string FillDisabledText = "fill: disabled";
        private const string FillEnabledText = "fill: enabled";
        private const string TextFileTxt = "Text File | *.txt";
        private const string XAxisCoordinateLabelText = "X:";
        private const string YAxisCoordinateLabelText = ", Y:";

        /// <summary>
        /// Initializes a new instance of the <see cref="frmMainForm"/> class.
        /// </summary>
        public frmMainForm()
        {
            InitializeComponent();
        }

        ///// <summary>
        ///// Handles the Click event of the Run button for the multi-line text box control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        //private void btnRunMultiline_Click(object sender, EventArgs e)
        //{
        //    Graphics g = picDrawingCanvas.CreateGraphics();

        //    try
        //    {
        //        string normalCommandsRegex = @"^([a-zA-Z]+) ?(\d+)? ?(\d+)?$";
        //        string expressionCommandsRegex = @"^[a-zA-Z]+\s*=\s*\d+$";

        //        if (Regex.IsMatch(txtCommandLine.Text.Trim().ToLower(), normalCommandsRegex))
        //        {
        //            var commandsList = _parser.ParseInput_MultiLine(txtCommandArea.Text);
        //            foreach (var command in commandsList)
        //            {
        //                ExecuteCommand(g, command);
        //            }
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        lblError.Text = exception.Message;
        //    }
        //}

        public Dictionary<string, int> VariablesDictionary = new Dictionary<string, int>();

        /// <summary>
        /// Handles the Click event of the Run button for the single-line text box control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnRun_Click(object sender, EventArgs e)
        {
            Graphics g = picDrawingCanvas.CreateGraphics();

            try
            {
                _cursor.Draw(g); // Draws a new cursor before every command in case it gets covered by another shape

                string[] inputSplitByLines = txtCommandArea.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                string regexType1 = @"^([a-zA-Z]+)\s*(\d+)?\s*(\d+)?$"; // "rectangle 100 150"
                string regexType2 = @"^var [a-zA-Z]+\s*=\s*\d+$"; // "var x = 5"
                string regexType3 = @"^([a-zA-Z]+)\s*([a-zA-Z]+)? ?([a-zA-Z]+)?$"; // "rectangle x y"
                Dictionary<string, int> dictionaryOfVariables = new Dictionary<string, int>();

                // "rectangle 100 150"
                if (Regex.IsMatch(txtCommandLine.Text.Trim().ToLower(), regexType1))
                {
                    CommandShape commandShape = _parser.ParseInput_SingleLine(txtCommandLine.Text);
                    ExecuteCommand(g, commandShape);

                    // Resets all the labels if execute command works
                    lblError.Text = "";
                    txtCommandLine.Text = "";
                }

                for (int i = 0; i < inputSplitByLines.Length; i++)
                {
                    // "rectangle x y"
                    if (Regex.IsMatch(inputSplitByLines[i].Trim().ToLower(), regexType3))
                    {
                        CommandShape commandShape = _parser.ParseInput_ShapeWithVariables(inputSplitByLines[i], dictionaryOfVariables);
                        ExecuteCommand(g, commandShape);
                    }

                    //"var x = 10"
                    if (Regex.IsMatch(inputSplitByLines[i].Trim().ToLower(), regexType2))
                    {
                        CommandVariable commandVariable = _parser.ParseInput_Variable(inputSplitByLines[i]);
                        dictionaryOfVariables.Add(commandVariable.VariableName, commandVariable.VariableValue);
                    }
                }

            }
            catch (IndexOutOfRangeException exception)
            {
                lblError.Text = "IndexOutOfRange exception:\n" + exception.Message;
            }

            catch (FormatException exception)
            {
                lblError.Text = "Format exception:\n" + exception.Message;
            }

            catch (ArgumentOutOfRangeException exception)
            {
                lblError.Text = "ArgumentOutOfRange Exception:\n" + exception.Message;
            }

            catch (ArgumentException exception)
            {
                lblError.Text = "Argument exception:\n" + exception.Message;
            }

            catch (Exception exception)
            {
                lblError.Text = "Other Exceptions:\n" + exception.Message;
            }
        }



        /// <summary>
        /// Executes all of my commands for various shapes and other commands.
        /// </summary>
        /// <param name="g">The graphics context from my picture box.</param>
        /// <param name="commandShape">Command class contains information about every command.</param>
        private void ExecuteCommand(Graphics g, CommandShape commandShape)
        {
            switch (commandShape.ActionWord)
            {
                case Action.run:
                    {
                        List<CommandShape> commands = _parser.ParseInput_MultiLine(txtCommandArea.Text);
                        foreach (CommandShape c in commands) { ExecuteCommand(g, c); }
                        break;
                    }
                case Action.move:
                    {
                        _cursor.MoveTo(new Point(commandShape.ActionValues[0], commandShape.ActionValues[1]));
                        _cursor.Draw(g);
                        lblCoordinatesValues.Text = XAxisCoordinateLabelText + _cursor.Position.X + YAxisCoordinateLabelText + _cursor.Position.Y;
                        break;
                    }
                case Action.fill:
                    {
                        if (commandShape.ActionValues[0].Equals(1))
                        {
                            _cursor.Fill = true;
                            lblFillState.Text = FillEnabledText;
                        }
                        if (commandShape.ActionValues[0].Equals(0))
                        {
                            _cursor.Fill = false;
                            lblFillState.Text = FillDisabledText;
                        }
                        break;
                    }
                case Action.reset:
                    {
                        _cursor.MoveTo(_cursor.DefaultPosition);
                        _cursor.ChangePenColor(_cursor.DefaultPenColor); // Resets cursor to default color (Red)
                        _cursor.ChangeFillState(_cursor.DefaultFill); // Resets cursor to default fill state (false ie; no fill)
                        _cursor.Draw(g);
                        lblCoordinatesValues.Text = XAxisCoordinateLabelText + _cursor.Position.X + YAxisCoordinateLabelText + _cursor.Position.Y;
                        lblFillState.Text = FillDisabledText;
                        lblPenColor.Text = PenColorRedText;
                        break;
                    }
                case Action.clear:
                    {
                        g.Clear(Color.White);
                        _cursor.Draw(g);
                        lblCoordinatesValues.Text = XAxisCoordinateLabelText + _cursor.Position.X + YAxisCoordinateLabelText + _cursor.Position.Y;
                        lblFillState.Text = FillDisabledText;
                        break;
                    }
                case Action.pen:
                    {
                        if (commandShape.ActionValues[0].Equals(1))
                        {
                            _cursor.PenColor = Color.Red;
                            lblPenColor.Text = PenColorRedText;
                        }
                        if (commandShape.ActionValues[0].Equals(2))
                        {
                            _cursor.PenColor = Color.Green;
                            lblPenColor.Text = PenColorGreenText;
                        }
                        if (commandShape.ActionValues[0].Equals(3))
                        {
                            _cursor.PenColor = Color.Blue;
                            lblPenColor.Text = PenColorBlueText;
                        }
                        _cursor.Draw(g);
                        break;
                    }
                default:
                    {
                        Shape shape = _shapeFactory.CreateShape(commandShape, _cursor.Position, _cursor.Fill, _cursor.PenColor);
                        shape.Draw(g);
                        _cursor.MoveTo(shape.Position);
                        _cursor.Draw(g);
                        lblCoordinatesValues.Text = XAxisCoordinateLabelText + _cursor.Position.X + YAxisCoordinateLabelText + _cursor.Position.Y;
                        break;
                    }
            }
        }

        /// <summary>
        /// Clears the picture box, resets the cursor, and resets the color and fill state of the cursor to default values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            var g = picDrawingCanvas.CreateGraphics();
            g.Clear(Color.White);
            _cursor.MoveTo(_cursor.DefaultPosition); // Resets cursor to default position (0,0)
            _cursor.ChangePenColor(_cursor.DefaultPenColor); // Resets cursor to default color (Red)
            _cursor.ChangeFillState(_cursor.DefaultFill); // Resets cursor to default fill state (false ie; no fill)
            _cursor.Draw(g);

            // Clearing all the labels in the WinForms window
            txtCommandLine.Text = "";
            lblError.Text = "";
            lblCoordinatesValues.Text = XAxisCoordinateLabelText + _cursor.Position.X + YAxisCoordinateLabelText + _cursor.Position.Y;
            lblFillState.Text = FillDisabledText;
            lblPenColor.Text = PenColorRedText;
        }

        /// <summary>
        /// Handles the KeyDown event of the txtCommandLine control allowing the user to execute commands on pressing Enter.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void TxtCommandLine_KeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        /// Handles the Paint event of the picture box control. Used to draw the cursor on the picture box every time the program starts.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void PictureBoxCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            _cursor.Draw(g);
        }

        /// <summary>
        /// Saves the text from the multi-line text box to a text file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Commands.txt";
            save.Filter = TextFileTxt;
            save.RestoreDirectory = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, txtCommandArea.Text);
            }
        }

        /// <summary>
        /// Loads text from a text file to the multi-line text.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = TextFileTxt;
            load.RestoreDirectory = true;

            if (load.ShowDialog() == DialogResult.OK)
            {
                txtCommandArea.Text = File.ReadAllText(load.FileName);
            }
        }

        /// <summary>
        /// Links to my GitHub page from the Menu Bar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AryanMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/aryanprince");
        }
    }
}
