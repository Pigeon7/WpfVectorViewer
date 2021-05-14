using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using WpfVectorViewer.Enums;
using WpfVectorViewer.Model;
using WpfVectorViewer.Services;

namespace WpfVectorViewer.ViewModel
{
    public class PrimitiveShapesViewModel
    {
        private readonly IReadPrimitivesService _readDataService;
        private readonly ICalculationsService _calculationsService;

        public ObservableCollection<PrimitiveComponent> PrimitiveComponentsList { get; set; }

        public Transform Transformation { get; set; }

        public PrimitiveShapesViewModel(IReadPrimitivesService readPrimitivesService, ICalculationsService calculationsService) 
        {
            _readDataService = readPrimitivesService;
            _calculationsService = calculationsService;
            PrimitiveComponentsList = new ObservableCollection<PrimitiveComponent>();

            List<PrimitiveComponent> allComponents = _readDataService.ReadPrimitivesFromFile(Constants.FILE_PATH);

            foreach (var component in allComponents)
            {
                PrimitiveComponentsList.Add(component);
            }
        }

        public void UpdateScale(double windowHeight, double windowWidth)
        {
            Transformation = _calculationsService.CalculateScale(GetAllEdgesOfComponents(PrimitiveComponentsList), windowHeight, windowWidth);
        }

        private List<Point> GetAllEdgesOfComponents(ObservableCollection<PrimitiveComponent> allComponents)
        {
            List<Point> points = new List<Point>();

            foreach (var component in allComponents)
            {
                switch (component.Type)
                {
                    case PrimitiveComponentType.Line:
                        var line = (LineModel) component;
                        points.Add(line.A);
                        points.Add(line.B);
                        break;
                    case PrimitiveComponentType.Cicrcle:
                        var circle = (CircleModel) component;
                        points.Add(new Point(circle.Center.X + circle.Diameter/2, circle.Center.Y + circle.Diameter / 2));
                        points.Add(new Point(circle.Center.X - circle.Diameter/2, circle.Center.Y + circle.Diameter / 2));
                        points.Add(new Point(circle.Center.X + circle.Diameter/2, circle.Center.Y - circle.Diameter / 2));
                        points.Add(new Point(circle.Center.X - circle.Diameter/2, circle.Center.Y - circle.Diameter / 2));
                        break;
                    case PrimitiveComponentType.Rectangle:
                        var rectangle = (RectangleModel)component;
                        points.AddRange(rectangle.Points);
                        break;
                    case PrimitiveComponentType.Triangle:
                        var triangle = (TriangleModel) component;
                        points.AddRange(triangle.Points);
                        break;
                }
            }

            return points;
        }
    }
}
