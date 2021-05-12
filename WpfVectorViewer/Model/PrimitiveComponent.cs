using System.Windows.Media;
using WpfVectorViewer.Enums;

namespace WpfVectorViewer.Model
{
    public abstract class PrimitiveComponent
    {
        public PrimitiveComponentType Type { get; set; }
        public Color Color { get; set; }
        public LineType LineType { get; set; }
    }
}
