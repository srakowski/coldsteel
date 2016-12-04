using Coldsteel.Configuration.Common;
using Coldsteel.Configuration.Controls;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Configuration
{
    public class Scene : ConfigurationObject
    {
        public string Name { get; set; }

        [ContentSerializer(Optional = true)]
        public bool IsStarting { get; set; }

        [ContentSerializer(Optional = true, CollectionItemName = "Asset")]
        public Content[] Content { get; set; }

        [ContentSerializer(Optional = true, CollectionItemName = "Control")]
        public Control[] Controls { get; set; }

        [ContentSerializer(Optional = true, CollectionItemName = "Layer")]
        public Layer[] Layers { get; set; }

        [ContentSerializer(Optional = true, CollectionItemName = "GameObject")]
        public GameObject[] GameObjects { get; set; }
    }
}
