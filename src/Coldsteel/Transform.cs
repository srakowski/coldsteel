// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Coldsteel
{
    /// <summary>
    /// This component determines a GameObject position in the world. All game
    /// objects will be required to have one, and only one, Transform component.
    /// </summary>
    public class Transform : Component
    {
        private Transform _parent;

        private List<Transform> _children = new List<Transform>();

        /// <summary>
        /// The parent of the transform.
        /// </summary>
        public Transform Parent => _parent;

        /// <summary>
        /// The children of the transform.
        /// </summary>
        public IEnumerable<Transform> Children => _children;

        /// <summary>
        /// The absolute position of the transform.
        /// </summary>
        public Vector2 Position
        {
            get { return Vector2.Transform(LocalPosition, _parent?.TransformationMatrix ?? Matrix.Identity); }
            set { LocalPosition = Vector2.Transform(value, _parent?.InvertedTransformationMatrix ?? Matrix.Identity); }
        }

        /// <summary>
        /// The posiition of the transform relative to its parent.
        /// </summary>
        public Vector2 LocalPosition { get; set; } = Vector2.Zero;

        /// <summary>
        /// The absolute rotation of the transform.
        /// </summary>
        public float Rotation
        {
            get { return LocalRotation + (_parent?.Rotation ?? 0f); }
            set { LocalRotation = value - (_parent?.Rotation ?? 0f); }
        }

        /// <summary>
        /// The rotation of the transform relative to its parent.
        /// </summary>
        public float LocalRotation { get; set; } = 0f;

        /// <summary>
        /// The absolute scale of the transform.
        /// </summary>
        public float Scale
        {
            get { return LocalScale + (_parent?.Scale - 1f ?? 0f); }
            set { LocalScale = value - (_parent?.Scale - 1f ?? 0f); }
        }

        /// <summary>
        /// The scale of the transform relative to its parent.
        /// </summary>
        public float LocalScale { get; set; } = 1f;

        public Matrix TransformationMatrix =>
            Matrix.Identity *
            Matrix.CreateRotationZ(this.Rotation) *
            Matrix.CreateScale(this.Scale) *
            Matrix.CreateTranslation(this.Position.X, this.Position.Y, 0f);

        internal Matrix InvertedTransformationMatrix =>
            Matrix.Invert(this.TransformationMatrix);

        /// <summary>
        /// Assigns a parent to this transform.
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(Transform parent)
        {
            _parent = parent;
            _parent._children.Add(this);
        }
    }
}
