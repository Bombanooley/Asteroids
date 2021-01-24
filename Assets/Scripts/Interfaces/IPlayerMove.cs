namespace Asteroids
{
    public interface IPlayerMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
}
