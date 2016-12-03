using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Coldsteel.Core
{
    internal class Transform
    {
        public GameObject GameObject { get; private set; }

        private Transform _parent;

        private List<Transform> _children = new List<Transform>();
        
        public Transform Parent => _parent;

        public IEnumerable<Transform> Children => _children;

        public Vector2 Position
        {
            get { return Vector2.Transform(LocalPosition, _parent?.TransformationMatrix ?? Matrix.Identity); }
            set { LocalPosition = Vector2.Transform(value, _parent?.InvertedTransformationMatrix ?? Matrix.Identity); }
        }

        public Vector2 LocalPosition { get; set; } = Vector2.Zero;

        public float Rotation
        {
            get { return LocalRotation + (_parent?.Rotation ?? 0f); }
            set { LocalRotation = value - (_parent?.Rotation ?? 0f); }
        }

        public float LocalRotation { get; set; } = 0f;

        public float Scale
        {
            get { return LocalScale + (_parent?.Scale - 1f ?? 0f); }
            set { LocalScale = value - (_parent?.Scale - 1f ?? 0f); }
        }

        public float LocalScale { get; set; } = 1f;

        internal Matrix TransformationMatrix =>
            Matrix.Identity *
            Matrix.CreateRotationZ(this.Rotation) *
            Matrix.CreateScale(this.Scale) *
            Matrix.CreateTranslation(this.Position.X, this.Position.Y, 0f);

        internal Matrix InvertedTransformationMatrix =>
            Matrix.Invert(this.TransformationMatrix);

        public Transform(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }

        public void SetParent(Transform parent)
        {
            _parent = parent;
            _parent._children.Add(this);
        }
    }
}
