using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Studio.ViewModels
{
    public class BehaviorsViewModel : ViewModelBase
    {
        public string Name { get; set; } = "Behaviors";

        public ObservableCollection<BehaviorViewModel> Children { get; } = new ObservableCollection<BehaviorViewModel>();
    }
}
