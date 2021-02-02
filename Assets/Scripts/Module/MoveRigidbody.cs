using UnityEngine;


namespace Asteroids
{
    internal class MoveRigidbody : IPlayerMove, IEnemyMove
    {
        private readonly Transform _transform;
        private readonly Rigidbody2D _rigitbody;
        private Vector2 _movePlayer;
        private Vector2 _moveEnemy;
        private float _forcePlayer = 10f;
        private float _forceEnemy = 10f;

        public float Speed { get; protected set; }

        public MoveRigidbody(Transform transform, Rigidbody2D rigidbody, float speed)
        {
            _transform = transform;
            _rigitbody = rigidbody;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime, Rigidbody2D rigidbody)
        {
            var speed = deltaTime * Speed * _forcePlayer;
            _movePlayer.Set(horizontal * speed, vertical * speed);
            rigidbody.AddForce(_movePlayer);
        }

        public void MoveEnemy(Vector3 direction, float deltaTime, Rigidbody2D rigidbody)
        {
            var speed = deltaTime * Speed * _forceEnemy;
            _moveEnemy.Set(direction.x * speed, direction.y * speed);
            //rigidbody.velocity = _moveEnemy * 50f;
            rigidbody.AddForce(_moveEnemy);
        }
    }
}
