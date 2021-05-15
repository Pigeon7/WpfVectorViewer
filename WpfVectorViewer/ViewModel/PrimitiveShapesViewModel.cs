using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using WpfVectorViewer.Enums;
using WpfVectorViewer.Model;
using WpfVectorViewer.Services;

namespace WpfVectorViewer.ViewModel
{
    public class PrimitiveShapesViewModel : INotifyPropertyChanged
    {
        private readonly IReadPrimitivesService _readDataService;
        private readonly ICalculationsService _calculationsService;
        private readonly IMessagingService _messagingService;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<PrimitiveComponent> PrimitiveComponentsList { get; set; }

        public Transform Transformation { get; set; }

        public PrimitiveShapesViewModel(IReadPrimitivesService readPrimitivesService, 
                                        ICalculationsService calculationsService,
                                        IMessagingService messagingService) 
        {
            _readDataService = readPrimitivesService;
            _calculationsService = calculationsService;
            _messagingService = messagingService;

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
            OnPropertyChanged("Transformation");
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void DisplayDetails(object component)
        {
            _messagingService.DisplayMessage(BuildMessage(component));
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

        private string BuildMessage(object component)
        {
            switch (component)
            { 
                case LineModel model:
                    return $"Point A: {model.A.X};{model.A.Y}\n Point B: {model.B.X};{model.B.Y}\n";
                case TriangleModel model:
                    return $"Point A: {model.Points[0].X};{model.Points[0].Y}\nPoint B: {model.Points[1].X};{model.Points[1].Y}\nPoint C: {model.Points[2].X};{model.Points[2].Y}\n";
                case RectangleModel model:
                    return $"Point A: {model.Points[0].X};{model.Points[0].Y}\nPoint B: {model.Points[1].X};{model.Points[1].Y}\nPoint C: {model.Points[2].X};{model.Points[2].Y}\nPoint D: {model.Points[3].X};{model.Points[3].Y}\n";
                case CircleModel model:
                    return $"Center Point: {model.Center.X};{model.Center.Y}\nDiameter: {model.Diameter}";
                default:
                    return "No matching component to view properties";
            }
        }
    }
}
