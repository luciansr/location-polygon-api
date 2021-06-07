using System;
using System.Collections.Generic;
using Geometry.Handlers;
using Geometry.Models;
using Xunit;

namespace Geometry.Tests.Handler
{
    public class IntersectionTests
    {
        [Fact]
        public void Segments_DoesntIntersect()
        {
            var list = new List<Tuple<Segment, Segment>>
            {
                new(
                    new Segment(new Point(1, 1), new Point(2, 2)),
                    new Segment(new Point(3, 3), new Point(4, 4))),
                new(
                    new Segment(new Point(0, 4), new Point(1, 3)),
                    new Segment(new Point(2, 2), new Point(3, 1))),
                new(
                    new Segment(new Point(1, 3), new Point(0, 4)),
                    new Segment(new Point(3, 1), new Point(2, 2))),
                new(
                    new Segment(new Point(0, 3), new Point(4, 7)),
                    new Segment(new Point(1, 0), new Point(2, 4))),
                new (
                    new Segment(new Point(3, 2), new Point(5, 2)),
                    new Segment(new Point(4, 3), new Point(4, 5)))
            };

            foreach (var item in list)
            {
                Assert.False(item.Item1.IntersectsWith(item.Item2));
                Assert.False(item.Item2.IntersectsWith(item.Item1));
            }
        }
        
        [Fact]
        public void DecimalSegments_DoesntIntersect()
        {
            var list = new List<Tuple<Segment, Segment>>
            {
                new(
                    new Segment(new Point(-72.2772825, 42.9295781), new Point(-72.2816169, 42.9260351)),
                    new Segment(new Point(-72.2776043, 42.9295545), new Point(-72.2816169, 42.9260351))),
                new(
                    new Segment(new Point(-43.1874275, -22.9495415), new Point(-43.1857324, -22.9495612)),
                    new Segment(new Point(-43.186596, -22.9495365), new Point(-43.1865907, -22.9489437))),
                new(
                    new Segment(new Point(-43.1874275, -22.9495415), new Point(-43.1857324, -22.9495612)),
                    new Segment(new Point(-43.1866068, -22.9489437), new Point(-43.1865907, double.MaxValue))),
            };

            foreach (var item in list)
            {
                Assert.False(item.Item1.IntersectsWith(item.Item2));
                Assert.False(item.Item2.IntersectsWith(item.Item1));
            }
        }

        [Fact]
        public void TwoSegments_Intersect()
        {
            var list = new List<Tuple<Segment, Segment>>
            {
                new(
                    new Segment(new Point(0, 0), new Point(1, 1)),
                    new Segment(new Point(0, 1), new Point(1, 0))),
                new (
                    new Segment(new Point(0, 3), new Point(4, 7)),
                    new Segment(new Point(1, 0), new Point(2, 6))),
                new (
                    new Segment(new Point(3, 2), new Point(5, 2)),
                    new Segment(new Point(4, 1), new Point(4, 3)))
            };

            foreach (var item in list)
            {
                Assert.True(item.Item1.IntersectsWith(item.Item2));
                Assert.True(item.Item2.IntersectsWith(item.Item1));
            }
        }

        [Fact]
        public void DecimalSegments_Intersect()
        {
            var list = new List<Tuple<Segment, Segment>>
            {
                new(
                    new Segment(new Point(-72.2772825d, 42.9295781), new Point(-72.2816169, 42.9260351)),
                    new Segment(new Point(-72.2776043, 42.9295545), new Point(-72.2813487, 42.9260194))),
                new(
                    new Segment(new Point(-167.34375, 64.7741253), new Point(-423.28125, -33.7243397)),
                    new Segment(new Point(-364.5703125, 57.1362393), new Point(-159.2578125, -20.9614396))),
                new(
                    new Segment(new Point(-43.1874275, -22.9495415), new Point(-43.1857324, -22.9495612)),
                    new Segment(new Point(-43.1866068, -22.9496995), new Point(-43.1865907, -22.9489437))),
                new(
                    new Segment(new Point(-43.1874275, -22.9495415), new Point(-43.1857324, -22.9495612)),
                    new Segment(new Point(-43.1866068, -22.9496995), new Point(-43.1865907, double.MaxValue))),
            };

            foreach (var item in list)
            {
                Assert.True(item.Item1.IntersectsWith(item.Item2));
                Assert.True(item.Item2.IntersectsWith(item.Item1));
            }
        }
    }
}