using Asteroids.Object_Pool;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Data
    {
        private Player _player;
        private Ship _ship;
        private Rigidbody2D _rigidbody;
        private EnemyPool _enemyPool;

        private List<Enemy> _listOfEnemies;
        private List<Vector3> _directionOfEnemies;


        public Player Player { get => _player; set => _player = value; }
        public Ship Ship { get => _ship; set => _ship = value; }
        public Rigidbody2D Rigidbody { get => _rigidbody; set => _rigidbody = value; }
        public EnemyPool EnemyPool { get => _enemyPool; set => _enemyPool = value; }
        public List<Enemy> ListOfEnemies { get => _listOfEnemies; set => _listOfEnemies = value; }
        public List<Vector3> DirectionOfEnemies { get => _directionOfEnemies; set => _directionOfEnemies = value; }


        public Data(Player player, Ship ship, Rigidbody2D rigidbody, EnemyPool enemyPool)
        {
            _player = player;
            _ship = ship;
            _rigidbody = rigidbody;
            _enemyPool = enemyPool;
        }

    }
}
