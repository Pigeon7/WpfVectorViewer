using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WpfVectorViewer.Model
{
    public class TriangleModel : PrimitiveComponent
    {
        public PointCollection Points => new PointCollection(new[] { A, B, C });
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Color FillColor{ get; set; }
    }
}
