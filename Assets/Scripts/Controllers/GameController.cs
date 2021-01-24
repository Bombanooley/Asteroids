using System.Collections.Generic;
using UnityEngine;
using Asteroids.Object_Pool;
using static Asteroids.NameManager;


namespace Asteroids
{
    class GameController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private CameraController _cameraController;

        private List<IController> _controllers = new List<IController>();
        private Ship _ship;
        
        public Vector3 direction;

        private void Start()
        {
            _player.InitializeShip();
            _ship = _player.Ship;

            _controllers.Add(_cameraController);
            _controllers.Add(new PlayerController(_player));
            _controllers.Add(new InputController(_player, _ship, _player));

            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy(ASTEROID);
            enemy.transform.position = Enemy.RandomPosition(_player.transform.position);
            enemy.gameObject.SetActive(true);

            Enemy.CreateAsteroidEnemy(new Health(100f), _player.transform.position);

            var factory = new AsteroidFactory();
            factory.Create(new Health(100f), _player.transform.position);

        }

        private void Update()
        {
            foreach (var item in _controllers)
                item.Updater();
        }
    }


}
