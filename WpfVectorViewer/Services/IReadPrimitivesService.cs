using System;
using System.Collections.Generic;
using System.Text;
using WpfVectorViewer.Model;

namespace WpfVectorViewer.Services
{
    public interface IReadPrimitivesService
    {
        List<PrimitiveComponent> ReadPrimitivesFromFile(string filePath); 
    }
}
