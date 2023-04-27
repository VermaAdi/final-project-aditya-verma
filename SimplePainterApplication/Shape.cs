using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePainterApplication
{
    /// <summary>
    /// Enum for defining the available shape types
    /// </summary>
    public enum ShapeType
    {
        Ellipse,
        Rect,
        Square,
        Circle,
        Star,
        Cloud,
        CloudToEllipse,
    }

    /// <summary>
    /// Represents a shape object with properties such as location, size, colors, and type
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Clones the current shape object
        /// </summary>
        /// <returns>Returns a new Shape instance with the same properties as the original</returns>
        public Shape Clone()
        {
            return new Shape
            {
                Type = Type,
                X = X,
                Y = Y,
                Width = Width,
                Height = Height,
                StrokeColor = StrokeColor,
                FillColor = FillColor,
                StrokeThickness = StrokeThickness,
                Filled = Filled,
                Selected = Selected
            };
        }

        public Color StrokeColor;
        public float StrokeThickness;
        public float X;
        public float Y;
        public float Width;
        public float Height;
        public Color FillColor;
        public bool Filled;
        public ShapeType Type;

        public List<PointF> Points;

        public bool Selected { get; set; }
        public Point Location { get; internal set; }

        /// <summary>
        /// Determines if the given point is within the shape's bounds
        /// </summary>
        /// <param name="location">The point to check</param>
        /// <returns>Returns true if the point is within the shape's bounds, otherwise false</returns>
        public bool Contains(Point location)
        {
            Rectangle rectangle = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
            return rectangle.Contains(location);
        }
    }
}
