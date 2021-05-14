using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfVectorViewer.Model
{
    public class CircleModel : PrimitiveComponent
    {
        public double TopOffset { get; set; }
        public double LeftOffset { get; set; }
        public Thickness Margin => new Thickness(LeftOffset, TopOffset, 0, 0);
        public double Diameter { get; set; }
        public Point Center { get; set; }
        public Color FillColor { get; set; }
    }
}
