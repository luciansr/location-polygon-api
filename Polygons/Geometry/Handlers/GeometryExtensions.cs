using System.Linq;
using System.Runtime.CompilerServices;
using Geometry.Models;

namespace Geometry.Handlers
{
    public static class GeometryExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IntersectsWith(this Segment current, Segment another)
        {
            var dx0 = current.B.X - current.A.X;
            var dx1 = another.B.X - another.A.X;
            var dy0 = current.B.Y - current.A.Y;
            var dy1 = another.B.Y - another.A.Y;
            var p0 = dy1 * (another.B.X - current.A.X) - dx1 * (another.B.Y - current.A.Y);
            var p1 = dy1 * (another.B.X - current.B.X) - dx1 * (another.B.Y - current.B.Y);
            var p2 = dy0 * (current.B.X - another.A.X) - dx0 * (current.B.Y - another.A.Y);
            var p3 = dy0 * (current.B.X - another.B.X) - dx0 * (current.B.Y - another.B.Y);

            return (p0 * p1 < 0) && (p2 * p3 < 0);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInsideOf(this Point point, Polygon polygon)
        {
            var pointLine = new Segment(point, new Point(point.X, double.MaxValue));
            var count = polygon.Segments.Count(segment => segment.IntersectsWith(pointLine));

            return count % 2 == 1;
        }
    }
}