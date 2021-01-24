using UnityEngine;

namespace Asteroids
{
    public interface IEnemyMove
    {
        float Speed { get; }
        void MoveEnemy(Vector3 direction, float deltaTime);
    }
}
