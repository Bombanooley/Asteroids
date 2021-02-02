using UnityEngine;

namespace Asteroids
{
    internal sealed class AccelerationMove : MoveRigidbody
    {
        private readonly float _acceleration;

        public AccelerationMove(Transform transform, Rigidbody2D rigidbody, float speed, float acceleration) : base(transform, rigidbody, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
