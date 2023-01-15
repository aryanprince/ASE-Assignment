using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public partial class MainForm : Form
    {
        // Instances of the classes that are used throughout the program, uses the Singleton design pattern
        private readonly Cursor _cursor = new Cursor();
        private readonly Parser _parser = new Parser();
        private readonly ShapeFactory _shapeFactory = new ShapeFactory();

        // Localized strings for WinForms controls
        private const string PenColorBlueText = "pen color: blue";
        private const string PenColorGreenText = "pen color: green";
        private const string PenColorRedText = "pen color: red";
        private const string FillDisabledText = "fill: disabled";
        private const string FillEnabledText = "fill: enabled";
        private const string TextFileTxt = "Text File| *.txt";
        private const string XAxisCoordinateLabelText = "X:";
        private const string YAxisCoordinateLabelText = ", Y:";

        private const string RegexDrawShapesWithNumbers = @"^([a-zA-Z]+)\s*(\d+)?\s*(\d+)?$"; // "rectangle 100 150" or "circle 50"
        Dictionary<string, int> _dictionaryOfVariables = new Dictionary<string, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the Run button for the program. Used to execute any commands that are entered into the text box.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnRun_Click(object sender, EventArgs e)
        {
            Graphics g = picDrawingCanvas.CreateGraphics();

            try
            {
                _cursor.Draw(g); // Draws a new cursor before every command in case it gets covered by another shape

                if (txtCommandArea.Text != string.Empty)
                {
                    List<Command> commandsList = _parser.Parse(txtCommandArea.Text, _dictionaryOfVariables);

                    for (int i = 0; i < commandsList.Count; i++)
                    {
                        if (commandsList[i] is CommandIfStatements)
                        {
                            CommandIfStatements command = (CommandIfStatements)commandsList[i];
                            if (command.IfState)
                            {
                                continue; // This will execute any code inside the if statement since it evaluates to true
                            }
                            else
                            {
                                i = command.EndIndex; // This will skip any code inside the if statements since it evaluates to false
                            }
                        }

                        else if (commandsList[i] is CommandWhile)
                        {
                            // Loop around through all the Commands inside the while statement until the "CommandEnd" object
                            CommandWhile command = (CommandWhile)commandsList[i];
                            int loopStart = i + 1;
                            int loopEnd = commandsList.FindIndex(loopStart, x => x is CommandEndKeyword) - 1; // Searches for an CommandEnd object only after the loopStart (ie within the while loop)

                            string[] inputSplitByLines = txtCommandArea.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                            string loopInput = "";

                            // Creating a new input string for the loop, this will include all the lines from beginning of loop declaration till and "endloop" type command
                            for (int loopCounter = loopStart; loopCounter <= loopEnd; loopCounter++)
                            {
                                loopInput += inputSplitByLines[loopCounter] + "\r\n";
                            }

                            // Looping through the input string for the specified number of times
                            for (int loopIndex = 1; loopIndex < command.LoopCount; loopIndex++)
                            {
                                List<Command> loopCommandsList = _parser.Parse(loopInput, _dictionaryOfVariables);
                                ExecuteCommand(g, (CommandShapeNum)loopCommandsList[1]);
                            }
                        }

                        else if (commandsList[i] is CommandShapeNum)
                        {
                            ExecuteCommand(g, (CommandShapeNum)commandsList[i]); // Draws regular shape commands
                        }
                    }
                }

                // "rectangle 100 150", "circle 50", "reset", or "run" (Basically any command)
                else if (Regex.IsMatch(txtCommandLine.Text.Trim().ToLower(), RegexDrawShapesWithNumbers))
                {
                    CommandShapeNum commandShapeNum = _parser.ParseDrawShape_WithNumbers(txtCommandLine.Text);
                    ExecuteCommand(g, commandShapeNum);
                }

                // Resets all the labels if execute command works
                lblError.Text = "";
                txtCommandLine.Text = "";
            }
            catch (ArgumentException exception)
            {
                lblError.Text = exception.Message;
            }

            catch (Exception exception)
            {
                lblError.Text = "UNEXPECTED ERROR:\n" + exception.Message;
            }
        }

        /// <summary>
        /// Executes all of my commands for various shapes and other commands.
        /// </summary>
        /// <param name="g">The graphics context from my picture box.</param>
        /// <param name="command">Command class contains information about every command.</param>
        private void ExecuteCommand(Graphics g, CommandShapeNum command)
        {
            switch (command.ActionWord)
            {
                case Action.move:
                    {
                        _cursor.MoveTo(new Point(command.ActionValues[0], command.ActionValues[1]));
                        _cursor.Draw(g);
                        lblCoordinatesValues.Text = XAxisCoordinateLabelText + _cursor.Position.X + YAxisCoordinateLabelText + _cursor.Position.Y;
                        break;
                    }
                case Action.fill:
                    {
                        if (command.ActionValues[0].Equals(1))
                        {
                            _cursor.Fill = true;
                            lblFillState.Text = FillEnabledText;
                        }
                        if (command.ActionValues[0].Equals(0))
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
                        if (command.ActionValues[0].Equals(1))
                        {
                            _cursor.PenColor = Color.Red;
                            lblPenColor.Text = PenColorRedText;
                        }
                        if (command.ActionValues[0].Equals(2))
                        {
                            _cursor.PenColor = Color.Green;
                            lblPenColor.Text = PenColorGreenText;
                        }
                        if (command.ActionValues[0].Equals(3))
                        {
                            _cursor.PenColor = Color.Blue;
                            lblPenColor.Text = PenColorBlueText;
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
