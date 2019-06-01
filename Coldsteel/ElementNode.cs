// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;

namespace Coldsteel
{
    internal class ElementNode
    {
        public ElementNode(ElementNode parent)
        {
            Parent = parent;
        }

        public ElementNode Parent { get; set; }

        public List<ElementNode> Children { get; set; }
    }
}
