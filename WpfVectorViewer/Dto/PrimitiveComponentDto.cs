using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace WpfVectorViewer.Dto
{
    [XmlType("element")]
    [Serializable]
    public class PrimitiveComponentDto
    {
        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("color")]
        public string Color { get; set; }

        [XmlElement("lineType")]
        public string LineType { get; set; }

        [XmlElement("a")]
        public string A { get; set; }

        [XmlElement("b")]
        public string B { get; set; }

        [XmlElement("c")]
        public string C { get; set; }

        [XmlElement("d")]
        public string D { get; set; }

        [XmlElement("center")]
        public string Center { get; set; }

        [XmlElement("radius")]
        public double Radius { get; set; }

        [XmlElement("filled")]
        public bool Filled { get; set; }
    }
}
