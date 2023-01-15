using System.Drawing;

namespace ASE_Assignment
{
    /// <summary>
    /// An interface that defines a contract for all shapes to implement. This interface is used to provide a common method for drawing shapes.
    /// </summary>
    public interface IShape
    {
        void Draw(Graphics g); // This method ensures any classes that implement this interface have a Draw method.
    }
}
