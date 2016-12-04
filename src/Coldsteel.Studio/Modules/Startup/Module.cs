using Gemini.Framework;
using System.ComponentModel.Composition;

namespace Coldsteel.Studio.Modules.Startup
{
    [Export(typeof(IModule))]
    public class Module : ModuleBase
    {
        public override void Initialize()
        {
            MainWindow.Title = "Coldsteel";
        }
    }
}
