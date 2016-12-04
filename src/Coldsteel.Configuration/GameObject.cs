using Coldsteel.Configuration.Common;
using Coldsteel.Configuration.Components;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Configuration
{
    public class GameObject : ConfigurationObject
    {
        public string Name { get; set; }

        [ContentSerializer(Optional = true, CollectionItemName = "Component")]
        public Component[] Components { get; set; }
    }
}
