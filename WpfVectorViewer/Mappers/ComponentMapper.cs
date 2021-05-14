﻿ using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using WpfVectorViewer.Dto;
using WpfVectorViewer.Enums;
using WpfVectorViewer.Model;

namespace WpfVectorViewer.Mappers
{
    public class ComponentMapper : IComponentMapper
    {
        public List<PrimitiveComponent> MapPrimitiveComponents(List<PrimitiveComponentDto> componenents) 
        {
            var mappedComponents = new List<PrimitiveComponent>();

            foreach (var component in componenents)
            {
                switch (component.Type.ToLower())
                {
                    case "line":
                        mappedComponents.Add(MapLineComponent(component));
                        break;
                    case "circle":
                        mappedComponents.Add(MapCircleComponent(component));
                        break;
                    case "triangle":
                        mappedComponents.Add(MapTriangleComponent(component));
                        break;
                    case "rectangle":
                        mappedComponents.Add(MapRectangleComponent(component));
                        break;
                }
            }
            return mappedComponents;
        }

        private CircleModel MapCircleComponent(PrimitiveComponentDto baseComponent) 
        {
            double CenterX = Convert.ToDouble(baseComponent.Center.Split(';')[0]);
            double CenterY = Convert.ToDouble(baseComponent.Center.Split(';')[1]);
            double radius = Convert.ToDouble(baseComponent.Radius);

            return new CircleModel()
            {
                Type = PrimitiveComponentType.Cicrcle,
                LineTypeArray = MapLineType(baseComponent.LineType),
                Color = MapColor(baseComponent.Color),
                Diameter = radius * 2,
                Center = new Point(CenterX, CenterY),
                TopOffset = CenterY - radius,
                LeftOffset = CenterX - radius,
                FillColor = baseComponent.Filled ? MapColor(baseComponent.Color) : Colors.Transparent
            };
        }
        private RectangleModel MapRectangleComponent(PrimitiveComponentDto baseComponent)
        {
            double Ax = Convert.ToDouble(baseComponent.A.Split(';')[0]);
            double Ay = Convert.ToDouble(baseComponent.A.Split(';')[1]);
            double Bx = Convert.ToDouble(baseComponent.B.Split(';')[0]);
            double By = Convert.ToDouble(baseComponent.B.Split(';')[1]);
            double Cx = Convert.ToDouble(baseComponent.C.Split(';')[0]);
            double Cy = Convert.ToDouble(baseComponent.C.Split(';')[1]);
            double Dx = Convert.ToDouble(baseComponent.D.Split(';')[0]);
            double Dy = Convert.ToDouble(baseComponent.D.Split(';')[1]);

            return new RectangleModel()
            {
                Type = PrimitiveComponentType.Rectangle,
                LineTypeArray = MapLineType(baseComponent.LineType),
                Color = MapColor(baseComponent.Color),
                Points = new PointCollection {
                    new Point(Ax, Ay),
                    new Point(Bx, By),
                    new Point(Cx, Cy),
                    new Point(Dx, Dy)
                },
                FillColor = baseComponent.Filled ? MapColor(baseComponent.Color) : Colors.Transparent
            };
        }
        
        private TriangleModel MapTriangleComponent(PrimitiveComponentDto baseComponent)
        {
            double Ax = Convert.ToDouble(baseComponent.A.Split(';')[0]);
            double Ay = Convert.ToDouble(baseComponent.A.Split(';')[1]);
            double Bx = Convert.ToDouble(baseComponent.B.Split(';')[0]);
            double By = Convert.ToDouble(baseComponent.B.Split(';')[1]);
            double Cx = Convert.ToDouble(baseComponent.C.Split(';')[0]);
            double Cy = Convert.ToDouble(baseComponent.C.Split(';')[1]);

            return new TriangleModel()
            {
                Type = PrimitiveComponentType.Triangle,
                LineTypeArray = MapLineType(baseComponent.LineType),
                Color = MapColor(baseComponent.Color),
                Points = new PointCollection {
                    new Point(Ax, Ay),
                    new Point(Bx, By),
                    new Point(Cx, Cy)
                },
                FillColor = baseComponent.Filled ? MapColor(baseComponent.Color) : Colors.Transparent
            };
        }
        
        private LineModel MapLineComponent(PrimitiveComponentDto baseComponent) 
        {
            double Ax = Convert.ToDouble(baseComponent.A.Split(';')[0]);
            double Ay = Convert.ToDouble(baseComponent.A.Split(';')[1]);
            double Bx = Convert.ToDouble(baseComponent.B.Split(';')[0]);
            double By = Convert.ToDouble(baseComponent.B.Split(';')[1]);

            return new LineModel()
            {
                Type = PrimitiveComponentType.Line,
                LineTypeArray = MapLineType(baseComponent.LineType),
                Color = MapColor(baseComponent.Color),
                A = new Point(Ax, Ay),
                B = new Point(Bx, By)
            };
        }

        private DoubleCollection MapLineType(string lineType) 
        {
            return (lineType.ToLower()) switch
            {
                "solid" => null,
                "dot" => new DoubleCollection { 1, 3, 1, 3 },
                "dash" => new DoubleCollection { 3, 3, 3, 3 },
                "dashdot" => new DoubleCollection { 1, 4, 4, 4 },
                _ => null
            };
        }

        private Color MapColor(string colorString)
        {
            var a = Convert.ToByte(colorString.Split(';')[0]);
            var r = Convert.ToByte(colorString.Split(';')[1]);
            var g = Convert.ToByte(colorString.Split(';')[2]);
            var b = Convert.ToByte(colorString.Split(';')[3]);

            return Color.FromArgb(a, r, g, b);
        }
    }
}
 