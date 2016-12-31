// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class BoxCollider : Collider
    {
        private Vector2[] _vertices;

        internal override Vector2[] Vertices => Shape.Vertices;

        internal override Vector2[] Edges => Shape.Edges;

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

            Shape.Vertices = new Vector2[_vertices.Length];
        }

        internal override void Activate(Context context) =>
            TransformShape();

        internal override void BeginPhysicsUpdate() =>
            TransformShape();

        private void TransformShape()
        {
            for (var i = 0; i < _vertices.Length; i++)
                Shape.Vertices[i] = Vector2.Transform(_vertices[i], Transform.TransformationMatrix);

            Shape.Update();
        }
    }
}
