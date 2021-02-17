using UnityEngine;
using Asteroids.Object_Pool;
using System.Collections.Generic;

namespace Asteroids
{
    public class EnemyController : IController
    {
        private readonly EnemyPool _enemyPool;
        private readonly Player _player;
        private readonly Rigidbody2D _rigidBody;
        private EnemyCountController _enemyCountController;
        private EnemyMoveController _enemyMoveController;
        private List<IExecute> _executeList = new List<IExecute>();
        private List<Enemy> _listOfEnemies = new List<Enemy>();
        private List<Vector3> _directionOfEnemies = new List<Vector3>();
        private float _timer = 0f;




        public EnemyController(Data data)
        {
            _enemyPool = data.EnemyPool;
            _player = data.Player;
            data.ListOfEnemies = _listOfEnemies;
            data.DirectionOfEnemies = _directionOfEnemies;
            _enemyCountController = new EnemyCountController(data);
            _executeList.Add(_enemyCountController);
            _enemyMoveController = new EnemyMoveController(data);
            _executeList.Add(_enemyMoveController);
        }

        public void Updater()
        {
            ReturnToPool();
            foreach (var item in _executeList)
                item.Execute();

            //DistanceCheck();

            for (int i = 0; i < _listOfEnemies.Count; i++)
                Debug.DrawRay(_listOfEnemies[i].transform.position, _directionOfEnemies[i], Color.red);

        }

        /// <summary>
        /// Возврат объекта в пул
        /// </summary>
        public void ReturnToPool()
        {
            for (int i = 0; i < _listOfEnemies.Count; i++)
            {
                if (!_listOfEnemies[i].gameObject.activeSelf)
                {
                    _listOfEnemies.Remove(_listOfEnemies[i]);
                    _directionOfEnemies.Remove(_directionOfEnemies[i]);
                }
            }
        }

        /// <summary>
        /// Проверка дистанции от игрока до врагов
        /// </summary>
        private void DistanceCheck()
        {
            for (int i = 0; i < _listOfEnemies.Count; i++)
            {
                var subtraction = _player.transform.position - _listOfEnemies[i].gameObject.transform.position;
                if (subtraction.sqrMagnitude > 16)
                    _listOfEnemies[i].ReturnToPool();
            }
        }

    }
}
