using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WpfVectorViewer.Model
{
    public class CircleModel : PrimitiveComponent
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        public Color FillColor { get; set; }
    }
}
