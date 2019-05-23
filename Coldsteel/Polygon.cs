// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Linq;

namespace Coldsteel
{
    internal struct Polygon
    {
        internal Vector2[] Vertices;

        internal Rectangle Bounds;

        internal Vector2[] Edges;

        public Polygon(Vector2[] vertices)
        {
            Vertices = vertices;

            var ys = Vertices.Select(v => (int)v.Y);
            var xs = Vertices.Select(v => (int)v.X);

            var mins = new Point(xs.Min(), ys.Min());
            var maxs = new Point(xs.Max(), ys.Max());

            Bounds = new Rectangle(mins, maxs - mins);

            Edges = new Vector2[Vertices.Length];
            for (var i = 0; i < Vertices.Length; i++)
            {
                var next = i + 1;
                if (next >= Vertices.Length)
                    next = 0;

                Edges[i] = Vertices[next] - Vertices[i];
            }
        }

        public Polygon Transform(Matrix transformMatrix)
        {
            return new Polygon(Vertices.Select(v => Vector2.Transform(v, transformMatrix)).ToArray());
        }
    }
}
