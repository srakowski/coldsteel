// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;

namespace Coldsteel
{
    public class Element
    {
        public Element(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The name of this custom element, prefer kebab-case
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The elements used by this custom element.
        /// </summary>
        public IEnumerable<Element> Elements { get; set; }

        /// <summary>
        /// The template describing the layout and bindings of this element.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Anonymous object containing methods that interact with events.
        /// </summary>
        public object Handlers { get; set; }

        internal ElementNode CreateTree(ElementNode parent)
        {
            var node = new ElementNode(parent);

            return node;
        }

        public static Element New(string name) => new Element(name);
    }
}
