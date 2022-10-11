namespace ASE_Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point pt1 = new Point(0, 0);
            Point pt2 = new Point(200, 200);
            Rectangle rect1 = new Rectangle(50, 80, 100, 130);
            Graphics g = e.Graphics;
            Pen myBlackPen = new Pen(Color.Black, 3);

            g.DrawLine(myBlackPen, pt1, pt2);
            g.DrawLine(myBlackPen, 0, 50, 200, 50);

            g.DrawEllipse(myBlackPen, 50, 50, 200, 100);

            g.DrawRectangle(myBlackPen, rect1);
            myBlackPen.Dispose();
        }
    }
}