namespace ASE_Assignment
{
    public partial class formAssignment : Form
    {
        public formAssignment()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Point pt1 = new Point(0, 0);
            //Point pt2 = new Point(200, 200);
            //Rectangle rect1 = new Rectangle(50, 80, 100, 130);
            //Graphics g = e.Graphics;
            //Pen myBlackPen = new Pen(Color.Black, 3);

            //g.DrawLine(myBlackPen, pt1, pt2);
            //g.DrawLine(myBlackPen, 0, 50, 200, 50);

            //g.DrawEllipse(myBlackPen, 50, 50, 200, 100);

            //g.DrawRectangle(myBlackPen, rect1);
            //myBlackPen.Dispose();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string fullCommand = txtboxCommandLine.Text;
            string[] splitCommand = fullCommand.Split(' ');

            if (splitCommand[0] == "rect")
            {
                Rectangle rect1 = new Rectangle(0, 0, System.Convert.ToInt32(splitCommand[1]), System.Convert.ToInt32(splitCommand[2]));
                Graphics g = picboxCanvas.CreateGraphics();
                Pen myBlackPen = new Pen(Color.Black, 3);
                g.DrawRectangle(myBlackPen, rect1);
                myBlackPen.Dispose();
            }

            if (splitCommand[0] == "circle")
            {
                Graphics g = picboxCanvas.CreateGraphics();
                Pen myBlackPen = new Pen(Color.Black, 3);
                g.DrawEllipse(myBlackPen, 50, 50, System.Convert.ToInt32(splitCommand[1]), System.Convert.ToInt32(splitCommand[2]));
                myBlackPen.Dispose();
            }
        }

        private void txtboxCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRun.PerformClick();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Graphics g = picboxCanvas.CreateGraphics();
            g.Clear(SystemColors.Control);
        }

        private void menuItemAddRect_Click(object sender, EventArgs e)
        {
            Rectangle rect1 = new Rectangle(0, 0, 100, 200);
            Graphics g = picboxCanvas.CreateGraphics();
            Pen myBlackPen = new Pen(Color.Black, 3);
            g.DrawRectangle(myBlackPen, rect1);
            myBlackPen.Dispose();
        }

        private void menuItemAddSquare_Click(object sender, EventArgs e)
        {
            Rectangle rect1 = new Rectangle(0, 0, 150, 150);
            Graphics g = picboxCanvas.CreateGraphics();
            Pen myBlackPen = new Pen(Color.Black, 3);
            g.DrawRectangle(myBlackPen, rect1);
            myBlackPen.Dispose();
        }
    }
}