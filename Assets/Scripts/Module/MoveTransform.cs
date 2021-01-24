using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IPlayerMove, IEnemyMove
    {
        private readonly Transform _transform;
        private Vector3 _move;

        public float Speed { get; protected set; }
        
        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical,  float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }

        public void MoveEnemy(Vector3 direction, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(direction.x * speed, direction.y * speed, 0.0f);
            _transform.localPosition += _move;
        }
    }
}
