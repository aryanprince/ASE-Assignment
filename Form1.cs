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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtboxCodeArea.Text = "Hello World";
            }

            if (e.KeyCode == Keys.R)
            {
                Rectangle rect1 = new Rectangle(50, 80, 100, 130);
                Graphics g = picboxCanvas.CreateGraphics();
                Pen myBlackPen = new Pen(Color.Black, 3);
                g.DrawRectangle(myBlackPen, rect1);
                myBlackPen.Dispose();
            }

            if (e.KeyCode == Keys.E)
            {
                Graphics g = picboxCanvas.CreateGraphics();
                Pen myBlackPen = new Pen(Color.Black, 3);
                g.DrawEllipse(myBlackPen, 50, 50, 200, 100);
                myBlackPen.Dispose();
            }
        }
    }
}