using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WpfVectorViewer.Services
{
    public class CalculationsService : ICalculationsService
    {

        public Transform CalculateScale(List<Point> points, double windowHeight, double windowWidth)
        {
            var edgeTop = points[0].Y;
            var edgeBot = points[0].Y;
            var edgeLeft = points[0].X;
            var edgeRight = points[0].X;

            foreach (var p in points)
            {
                if (p.X < edgeLeft)
                {
                    edgeLeft = p.X;
                }
                if (p.X > edgeRight)
                {
                    edgeRight = p.X;
                }
                if (p.Y < edgeTop)
                {
                    edgeTop = p.Y;
                }
                if (p.Y > edgeBot)
                {
                    edgeBot = p.Y;
                }
            }

            var height = edgeBot - edgeTop;
            var width = edgeRight - edgeLeft;

            var translate = new TranslateTransform(-edgeLeft, -edgeTop);
            var lesserScale = width / windowWidth > height / windowHeight ? height / windowHeight : width / windowWidth;
            ScaleTransform scale = new ScaleTransform(lesserScale, lesserScale);
            TransformGroup transformGroup = new TransformGroup();

            transformGroup.Children.Add(translate);
            transformGroup.Children.Add(scale);

            return transformGroup;
        }
    }
}
