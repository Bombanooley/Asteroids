using UnityEngine;
using Asteroids.Object_Pool;
using System.Collections.Generic;
using static Asteroids.NameManager;
using static UnityEngine.Random;

namespace Asteroids
{
    public class EnemyCountController : IExecute
    {
        private Player _player;
        private List<Enemy> _listOfEnemies;
        private EnemyPool _enemyPool;
        private List<Vector3> _directionOfEnemies;

        public EnemyCountController(Data data)
        {
            _player = data.Player;
            _listOfEnemies = data.ListOfEnemies;
            _enemyPool = data.EnemyPool;
            _directionOfEnemies = data.DirectionOfEnemies;
        }

        public void Execute ()
        {
            if (_listOfEnemies.Count < 15)
                AsteroidSpawn(_enemyPool);
        }

        /// <summary>
        /// Спавн астероида из пула
        /// </summary>
        /// <param name="enemyPool">Пул врагов</param>
        private void AsteroidSpawn(EnemyPool enemyPool)
        {
            var enemy = enemyPool.GetEnemy(ASTEROID);
            enemy.ActivateEnemy(Enemy.RandomPosition(_player.transform.position));
            _listOfEnemies.Add(enemy);
            _directionOfEnemies.Add(RandomDirection());
        }

        /// <summary>
        /// Выбор случайного направления
        /// </summary>
        /// <returns></returns>
        private Vector3 RandomDirection()
        {
            var vector = new Vector3(Range(-1f, 1f), Range(-1f, 1f));
            return vector;
        }
    }
}
