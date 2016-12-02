using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coldsteel.Components;

namespace Coldsteel.DeveloperTools.ViewModels
{
    abstract class GameObjectComponentViewModel : ViewModelBase
    {
        public abstract string Type { get; }
    }
}
