// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    internal class Polygon
    {    
        private Vector2[] _vertices;

        internal Rectangle Bounds { get; private set; }

        internal Vector2[] Vertices
        {
            get { return _vertices; }
            set
            {
                _vertices = value;
                Update();
            }
        }

        internal Vector2[] Edges { get; private set; }

        internal void Update()
        {
            UpdateBounds();
            UpdateEdges();
        }

        private void UpdateBounds()
        {
            var mins = new Point();
            var maxs = new Point();
            for (var i = 0; i < _vertices.Length; i++)
            {
                var vert = _vertices[i];
                if (i == 0)
                {
                    mins = vert.ToPoint();
                    maxs = vert.ToPoint();
                    continue;
                }

                mins.X = (int)Math.Min(vert.X, mins.X);
                mins.Y = (int)Math.Min(vert.Y, mins.Y);
                maxs.X = (int)Math.Max(vert.X, maxs.X);
                maxs.Y = (int)Math.Max(vert.Y, maxs.Y);
            }

            Bounds = new Rectangle(mins, maxs - mins);
        }

        private void UpdateEdges()
        {
            Edges = new Vector2[_vertices.Length];
            for (var i = 0; i < _vertices.Length; i++)
            {
                var next = i + 1;
                if (next >= _vertices.Length)
                    next = 0;

                Edges[i] = _vertices[next] - _vertices[i];
            }
        }
    }
}
