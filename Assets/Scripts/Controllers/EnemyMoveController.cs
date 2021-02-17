using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;



namespace Asteroids
{
    public class EnemyMoveController : IExecute
    {
        private List<Enemy> _listOfEnemies;
        private List<Vector3> _directionOfEnemies;
        private float _timer;
        private const float TIMER_COUNT = 3f;
        private const float DIRECTION_CHANGE_CHANCE = 0.3f;

        public EnemyMoveController(Data data)
        {
            _listOfEnemies = data.ListOfEnemies;
            _directionOfEnemies = data.DirectionOfEnemies;
            data.DirectionOfEnemies.Add(RandomDirection());
            _timer = 0f;
        }
        public void Execute()
        {
            MoveEnemies();
            Timer();
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
        /// Смена направления по таймеру
        /// </summary>
        private void Timer()
        {
            
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
    }
}

