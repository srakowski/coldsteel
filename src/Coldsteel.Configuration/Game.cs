using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Configuration
{
    public class Game
    {
        public string Title { get; set; }

        public string[] Assemblies { get; set; }

        public string[] Scenes { get; set; }

        public string StartingSceneId { get; set; }
    }
}
