using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Studio.ViewModels
{
    public class ContentViewModel : ViewModelBase
    {
        public string Name { get; set; } = "Content";

        public ObservableCollection<ContentItemViewModel> Children { get; } = new ObservableCollection<ContentItemViewModel>();
    }
}
