namespace Coldsteel
{
    public struct Collision
    {
        public Collision(Entity entity1, Entity entity2)
        {
            Entity1 = entity1;
            Entity2 = entity2;
        }

        public Entity Entity1 { get; }

        public Entity Entity2 { get; }
    }
}
