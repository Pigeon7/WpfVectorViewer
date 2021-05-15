using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WpfVectorViewer.Model;
using Newtonsoft.Json;
using WpfVectorViewer.Dto;
using WpfVectorViewer.Mappers;
using System.Xml.Serialization;

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
            List<PrimitiveComponentDto> primitivesDtos;
            string fileExtension = filePath.Split('.')[1];
            string fileContent = File.ReadAllText(filePath);

            switch (fileExtension)
            {
                case "json":
                    primitivesDtos = JsonConvert.DeserializeObject<List<PrimitiveComponentDto>>(fileContent);
                    break;
                case "xml":
                    var serializer = new XmlSerializer(typeof(List<PrimitiveComponentDto>), new XmlRootAttribute("root"));
                    var xmlStringReader = new StringReader(fileContent);
                    primitivesDtos = (List<PrimitiveComponentDto>) serializer.Deserialize(xmlStringReader);
                    break;
                default:
                    throw new Exception("NOT SUPPORTED DATA FILE FORMAT!");
            }

            return _mapper.MapPrimitiveComponents(primitivesDtos);
        }
    }
}
