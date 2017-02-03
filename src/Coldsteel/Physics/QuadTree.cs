// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Physics
{
    internal struct QuadTree
    {
        public readonly List<Collider> Colliders;

        private readonly Polygon _shape;

        private readonly QuadTree[] _nodes;

        public QuadTree(Vector2 ul, Vector2 lr, int depth)
        {
            Colliders = new List<Collider>();

            var ur = new Vector2(lr.X, ul.Y);
            var ll = new Vector2(ul.X, lr.Y);
            _shape = new Polygon()
            {
                Vertices = new[]
                {
                        ul,
                        ur,
                        lr,
                        ll
                }
            };

            if (depth == 0)
            {
                _nodes = new QuadTree[] { };
                return;
            }

            var hw = (lr.X - ul.X) / 2f;
            var hh = (lr.Y - ul.Y) / 2f;
            _nodes = new QuadTree[]
            {
                new QuadTree(new Vector2(ul.X, ul.Y), new Vector2(ul.X + hw, ul.Y + hh), depth - 1),
                new QuadTree(new Vector2(ul.X + hw, ul.Y), new Vector2(lr.X, ul.Y + hh), depth - 1),
                new QuadTree(new Vector2(ul.X, ul.Y + hh), new Vector2(ul.X + hw, lr.Y), depth - 1),
                new QuadTree(new Vector2(ul.X + hw, ul.Y + hh), new Vector2(lr.X, lr.Y), depth - 1)
            };
        }

        public void Add(Collider collider)
        {
            if (!collider.Shape.Bounds.Intersects(this._shape.Bounds))
                return;

            if (!_nodes.Any())
            {
                Colliders.Add(collider);
                return;
            }

            for (int i = 0; i < _nodes.Length; i++)
                _nodes[i].Add(collider);
        }

        public IEnumerable<QuadTree> Walk()
        {
            yield return this;
            foreach (var node in _nodes.SelectMany(n => n.Walk()))
                yield return node;
        }
    }
}
