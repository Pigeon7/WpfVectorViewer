using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WpfVectorViewer.Services
{
    public interface ICalculationsService
    {
        Transform CalculateScale(List<Point> points, double windowHeight, double windowWidth);
    }
}
