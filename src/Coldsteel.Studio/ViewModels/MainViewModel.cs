using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Studio.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentViewModel;

        public string WindowTitle { get; } = "Coldsteel Studio";

        public MainViewModel()
        {
            this.CurrentViewModel = new GameViewModel();
        }

        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged();
            }
        }
    }
}
