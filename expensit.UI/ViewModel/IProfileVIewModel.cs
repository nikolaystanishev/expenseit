using expensit.UI.Core;
using System;

namespace expensit.UI.ViewModel
{
    public interface IProfileVIewModel : IViewModelBase
    {
        void SetMainLoad(Action mainLoad);
    }
}
