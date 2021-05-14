using System.Windows.Media;
using System.Windows.Shapes;
using WpfVectorViewer.Enums;

namespace WpfVectorViewer.Model
{
    public abstract class PrimitiveComponent
    {
        public PrimitiveComponentType Type { get; set; }
        public Color Color { get; set; }
        public DoubleCollection LineTypeArray { get; set; }
    }
}
