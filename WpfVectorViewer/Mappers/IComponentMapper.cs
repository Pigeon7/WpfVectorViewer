 using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using WpfVectorViewer.Dto;
using WpfVectorViewer.Enums;
using WpfVectorViewer.Model;

namespace WpfVectorViewer.Mappers
{
    public interface IComponentMapper
    {
        List<PrimitiveComponent> MapPrimitiveComponents(List<PrimitiveComponentDto> componenents);
    }
}
 