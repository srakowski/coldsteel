using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class Transform
    {
        private Transform _parent;

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

        public void SetParent(Transform parent)
        {
            this._parent = parent;
            // TODO: ensure no recursive parents
        }
    }
}
