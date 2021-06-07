using System;
using System.Collections.Generic;
using Geometry.Handlers;
using Geometry.Models;
using Xunit;

namespace Geometry.Tests.Handler
{
    public class PolygonTests
    {
        [Fact]
        public void Point_IsInside_Polygon()
        {
            var list = new List<Tuple<Point, Polygon>>
            {
                new(
                    new Point(-43.1866685, -22.9498576),
                    new Polygon(new []
                    {
                        new Point(-43.1867543,  -22.949497), 
                        new Point(-43.186824, -22.9503071),
                        new Point(-43.1864351, -22.9496674),
                    }))
            };

            foreach (var item in list)
            {
                Assert.True(item.Item1.IsInsideOf(item.Item2));
            }
        }
        
        [Fact]
        public void Point_IsOutside_Polygon()
        {
            var list = new List<Tuple<Point, Polygon>>
            {
                new(
                    new Point(-43.1865786, -22.9499329),
                    new Polygon(new []
                    {
                        new Point(-43.1867543,  -22.949497), 
                        new Point(-43.186824, -22.9503071),
                        new Point(-43.1864351, -22.9496674),
                    })),
                new(
                    new Point(-43.1865786, -22.9499329),
                    new Polygon(new []
                    {
                        new Point(-43.1867543,  -22.949497), 
                        new Point(-43.186824, -22.9503071)
                    }))
            };

            foreach (var item in list)
            {
                Assert.False(item.Item1.IsInsideOf(item.Item2));
            }
        }
    }
}