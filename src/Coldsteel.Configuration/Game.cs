using Coldsteel.Configuration.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Configuration
{
    public class Game
    {
        public string Title { get; set; }

        public Content[] Content { get; set; }

        public string[] Scenes { get; set; }
    }
}
