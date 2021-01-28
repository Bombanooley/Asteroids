using UnityEngine;


namespace Asteroids
{
    public sealed class Ship : IPlayerMove, IRotation
    {
        private readonly IPlayerMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly Rigidbody2D _rigidBody;

        public float Speed => _moveImplementation.Speed;

        public Ship(IPlayerMove moveImplementation, IRotation rotationImplementation, Rigidbody2D rigidbody)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _rigidBody = rigidbody;
        }

        public void Move(float horizontal, float vertical, float deltaTime, Rigidbody2D rigidbody)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime, rigidbody);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}
