// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Core2D
{
    public class Transform2D : Transform
    {
        /// <summary>
        /// Static instance to use as transform when no parent.
        /// </summary>
        private static Transform2D Zero { get; } = new Transform2D();

        /// <summary>
        /// Get's the Entity's parent transform or returns the static Zero transform.
        /// </summary>
        private Transform2D ParentTransform =>
            Entity
                .Bind(e => e.Parent)
                .Bind(p => p.Transform)
                .OfType<Transform2D>()
                .GetValueOr(() => Zero);

        /// <summary>
        /// The absolute position of the transform.
        /// </summary>
        public Vector2 Position
        {
            get { return Vector2.Transform(LocalPosition, ParentTransform.TransformationMatrix); }
            set { LocalPosition = Vector2.Transform(value, Matrix.Invert(ParentTransform.TransformationMatrix)); }
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
            get { return LocalRotation + (ParentTransform.Rotation); }
            set { LocalRotation = value - (ParentTransform.Rotation); }
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
            get { return LocalScale + (ParentTransform.Scale - 1f); }
            set { LocalScale = value - (ParentTransform.Scale - 1f); }
        }

        /// <summary>
        /// The scale of the transform relative to its parent.
        /// </summary>
        public float LocalScale { get; set; } = 1f;

        /// <summary>
        /// A Transformation Matrix based on this 2D transform.
        /// </summary>
        public Matrix TransformationMatrix =>
            Matrix.Identity *
            Matrix.CreateRotationZ(Rotation) *
            Matrix.CreateScale(Scale) *
            Matrix.CreateTranslation(Position.X, Position.Y, 0f);
    }
}
