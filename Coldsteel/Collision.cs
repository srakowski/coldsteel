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

            TopOfTarget = sourceBounds.Bottom >= targetBounds.Top && sourceBounds.Top <= targetBounds.Top;

            BottomOfTarget = sourceBounds.Top <= targetBounds.Bottom && sourceBounds.Bottom >= targetBounds.Bottom;

            LeftOfTarget = sourceBounds.Right >= targetBounds.Left && sourceBounds.Left <= targetBounds.Left;

            RightOfTarget = sourceBounds.Left <= targetBounds.Right && sourceBounds.Right >= targetBounds.Right;
        }

        public Collider SourceCollider { get; }

        public bool TopOfTarget { get; }

        public bool BottomOfTarget { get; }

        public bool LeftOfTarget { get; }

        public bool RightOfTarget { get; }

        public Collider TargetCollider { get; }
    }
}
