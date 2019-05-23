namespace Coldsteel
{
    public struct Collision
    {
        public Collision(Collider sourceCollider, Collider targetCollider)
        {
            SourceCollider = sourceCollider;
            TargetCollider = targetCollider;

            var sourceBounds = sourceCollider.Bounds;
            var targetBounds = targetCollider.Bounds;

            TopOfTarget = sourceBounds.Center.Y < targetBounds.Top && sourceBounds.Bottom >= targetBounds.Top;
            BottomOfTarget = sourceBounds.Center.Y > targetBounds.Bottom && sourceBounds.Top <= targetBounds.Bottom;

            LeftOfTarget = sourceBounds.Center.X < targetBounds.Left && sourceBounds.Right >= targetBounds.Left;
            RightOfTarget = sourceBounds.Center.X > targetBounds.Right && sourceBounds.Left <= targetBounds.Right;
        }

        public Collider SourceCollider { get; }

        public bool TopOfTarget { get; }

        public bool BottomOfTarget { get; }

        public bool LeftOfTarget { get; }

        public bool RightOfTarget { get; }

        public Collider TargetCollider { get; }
    }
}
