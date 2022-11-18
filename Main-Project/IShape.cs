using System.Drawing;

namespace ASE_Assignment
{
    /// <summary>
    /// An interface for all shapes to implement. This is used to draw shapes.
    /// </summary>
    public interface IShape
    {
        void Draw(Graphics g); // This method ensures any classes that implement this interface have a Draw method.
    }
}
