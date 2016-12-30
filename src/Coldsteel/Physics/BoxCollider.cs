// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class BoxCollider : Collider
    {
        private Vector2[] _vertices;

        private Vector2[] _translatedVertices;

        private Vector2[] _edges;

        internal override Vector2[] Vertices => _translatedVertices;

        internal override Vector2[] Edges => _edges;

        public BoxCollider(float dim) : this(dim, dim) { }

        public BoxCollider(float width, float height)
        {
            var halfW = width / 2f;
            var halfH = height / 2f;

            _vertices = new[]
            {
                new Vector2(-halfW, -halfH),
                new Vector2(halfW, -halfH),
                new Vector2(halfW, halfH),
                new Vector2(-halfW, halfH)
            };

            _translatedVertices = new Vector2[_vertices.Length];
            _edges = new Vector2[_vertices.Length];
        }

        internal override void Update()
        {
            for (var i = 0; i < _vertices.Length; i++)
            {
                _translatedVertices[i] = Vector2.Transform(_vertices[i], Transform.TransformationMatrix);

                var next = i + 1;
                if (next >= _vertices.Length)
                    next = 0;

                _edges[i] = _translatedVertices[next] - _translatedVertices[i];
            }
        }
    }
}
