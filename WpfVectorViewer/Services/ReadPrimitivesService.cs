using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WpfVectorViewer.Model;
using Newtonsoft.Json;
using WpfVectorViewer.Dto;
using WpfVectorViewer.Mappers;

namespace WpfVectorViewer.Services
{
    public class ReadPrimitivesService : IReadPrimitivesService
    {
        private readonly IComponentMapper _mapper;

        public ReadPrimitivesService(IComponentMapper mapper)
        {
            _mapper = mapper;
        }
        public List<PrimitiveComponent> ReadPrimitivesFromFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);

            var primitivesDtos = JsonConvert.DeserializeObject<List<PrimitiveComponentDto>>(fileContent);

            return _mapper.MapPrimitiveComponents(primitivesDtos);
        }

       
    }
}
