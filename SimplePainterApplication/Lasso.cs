using System.Collections.Generic;
using System.Drawing;

public class Lasso
{
    public List<Point> Points { get; private set; } = new List<Point>();

    public void AddPoint(Point point)
    {
        Points.Add(point);
    }

    public void Clear()
    {
        Points.Clear();
    }

    public bool IsPointInside(Point point)
    {
        bool isInside = false;
        int j = Points.Count - 1;

        for (int i = 0; i < Points.Count; i++)
        {
            if (Points[i].Y < point.Y && Points[j].Y >= point.Y || Points[j].Y < point.Y && Points[i].Y >= point.Y)
            {
                if (Points[i].X + (point.Y - Points[i].Y) / (float)(Points[j].Y - Points[i].Y) * (Points[j].X - Points[i].X) < point.X)
                {
                    isInside = !isInside;
                }
            }
            j = i;
        }

        return isInside;
    }
}

