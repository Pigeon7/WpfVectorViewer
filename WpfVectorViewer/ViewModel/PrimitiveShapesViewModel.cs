using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using WpfVectorViewer.Enums;
using WpfVectorViewer.Model;
using WpfVectorViewer.Services;

namespace WpfVectorViewer.ViewModel
{
    public class PrimitiveShapesViewModel
    {
        private readonly IReadPrimitivesService _readDataService;
        public ObservableCollection<PrimitiveComponent> PrimitiveComponentsList { get; set; }

        //public PrimitiveShapesViewModel() 
        //{
        //    //Required default constructor 
        //}

        public PrimitiveShapesViewModel(IReadPrimitivesService service) 
        {
            _readDataService = service;
            PrimitiveComponentsList = new ObservableCollection<PrimitiveComponent>();

            List<PrimitiveComponent> allComponents = _readDataService.ReadPrimitivesFromFile(Constants.FILE_PATH);

            foreach (var component in allComponents)
            {
                PrimitiveComponentsList.Add(component);
            }


        }
    }
}
