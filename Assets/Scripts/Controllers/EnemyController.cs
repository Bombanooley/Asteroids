using UnityEngine;
using Asteroids.Object_Pool;
using System.Collections.Generic;
using static Asteroids.NameManager;
using static UnityEngine.Random;

namespace Asteroids
{
    public class EnemyController : IController
    {
        private readonly EnemyPool _enemyPool;
        private readonly Player _player;
        private readonly Rigidbody2D _rigidBody;
        private List<Enemy> _listOfEnemies = new List<Enemy>();
        private List<Vector3> _directionOfEnemies = new List<Vector3>();
        private float _timer = 0f;
        private const float TIMER_COUNT = 3f;
        private const float DIRECTION_CHANGE_CHANCE = 0.3f;


        public EnemyController(EnemyPool enemyPool, Player player)
        {
            _enemyPool = enemyPool;
            _player = player;
        }

        public void Updater()
        {
            if (_listOfEnemies.Count < 5)
                AsteroidSpawn(_enemyPool);
            MoveEnemies();

            for (int i = 0; i < _listOfEnemies.Count; i++)
                Debug.DrawRay(_listOfEnemies[i].transform.position, _directionOfEnemies[i], Color.red);
            
            _timer += Time.deltaTime;
            if (_timer > TIMER_COUNT)
            {
                for (int i = 0; i < _directionOfEnemies.Count; i++)
                {
                    var random = value;
                    if (random > DIRECTION_CHANGE_CHANCE) _directionOfEnemies[i] = RandomDirection();
                    }
                _timer = 0f;
            }
        }

        /// <summary>
        /// Движение врагов 
        /// </summary>
        private void MoveEnemies()
        {
            for (int i = 0; i < _listOfEnemies.Count; i++)
            {
                DisactivationCheck(i);
                _listOfEnemies[i].MoveEnemy(_directionOfEnemies[i], Time.deltaTime);
            }
        }
        /// <summary>
        /// Проверка дизактивированных врагов и их исключение из списков
        /// </summary>
        /// <param name="i"></param>
        private void DisactivationCheck(int i)
        {
            if (!_listOfEnemies[i].gameObject.activeSelf)
            {
                _listOfEnemies.Remove(_listOfEnemies[i]);
                _directionOfEnemies.Remove(_directionOfEnemies[i]);
            }
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
    }
}
