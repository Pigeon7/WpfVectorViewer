using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WpfVectorViewer.Model
{
    public class RectangleModel : PrimitiveComponent
    {
        public PointCollection Points { get; set; }
        public Color FillColor{ get; set; }
    }
}
