using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Studio.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> References = new ObservableCollection<string>();




        //private object _selectedItem = null;

        //private BehaviorsViewModel _behaviors = new BehaviorsViewModel();

        //private ContentViewModel _content = new ContentViewModel();

        //private ScenesViewModel _scenes = new ScenesViewModel();

        //public List<object> Children { get; set; } = new List<object>();

        //public RelayCommand NewSceneCommand { get; }

        //public object SelectedItem
        //{
        //    get { return _selectedItem; }
        //    set
        //    {
        //        _selectedItem = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //public GameViewModel()
        //{
        //    Children.Add(_behaviors);
        //    Children.Add(_content);
        //    Children.Add(_scenes);
        //    NewSceneCommand = new RelayCommand(NewScene);
        //}

        //private void NewScene()
        //{
        //    _scenes.NewScene();
        //}
    }
}
