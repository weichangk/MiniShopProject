using System;

namespace MediaKitWpfApp.Common
{
    public interface ITopWidgetOper
    {
        Action Home { get; set; }
        Action Menu { get; set; }
        Action Min { get; set; }
        Action Close { get; set; }
    }
}
