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
        public Content[] Content { get; set; }

        [ContentSerializer(Optional = true)]
        public Layer[] Layers { get; set; }

        [ContentSerializer(Optional = true)]
        public GameObject[] GameObjects { get; set; }
    }
}
