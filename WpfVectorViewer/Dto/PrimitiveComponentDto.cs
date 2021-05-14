using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WpfVectorViewer.Dto
{
    public class PrimitiveComponentDto
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public string LineType { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Center { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }
    }
}
