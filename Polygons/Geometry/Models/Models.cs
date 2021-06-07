namespace Geometry.Models
{
    public record Point(double X, double Y);

    public record Segment(Point A, Point B);

    public class Polygon
    {
        public Segment[] Segments { get; }
        
        public Polygon(Point[] points)
        {
            if (points.Length < 3)
            {
                Segments = new Segment[0];
            }
            else
            {
                Segments = new Segment[points.Length];
                for (var i = 1; i < points.Length; ++i)
                {
                    Segments[i - 1] = new Segment(points[i - 1], points[i]);
                }
                Segments[^1] = new Segment(points[^1], points[0]);
            }
        }
    };
}