using System.Collections.Generic;
using UnityEngine;
using Asteroids.Object_Pool;


namespace Asteroids
{
    class GameController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private OutOfDisplayCheker _outOfDisplayCheker;
        [SerializeField] private CameraController _cameraController;


        private List<IController> _controllers = new List<IController>();
        private Ship _ship;
        private Rigidbody2D _rigidbody;
        private EnemyPool _enemyPool;
        private Data _data;

        public Vector3 direction;

        private void Start()
        {
            Initializer();


            //Enemy.CreateAsteroidEnemy(new Health(100f), _player.transform.position);
            //var factory = new AsteroidFactory();
            //factory.Create(new Health(100f), _player.transform.position);
        }

        private void Initializer()
        {
            _player.InitializeShip(ref _ship);
            _rigidbody = _player.GetComponent<Rigidbody2D>();
            _enemyPool = new EnemyPool(15);
            _data = new Data(_player, _ship, _rigidbody, _enemyPool);

            _controllers.Add(_cameraController);
            _controllers.Add(new PlayerController(_data, _outOfDisplayCheker));
            _controllers.Add(new InputController(_data));
            _controllers.Add(new EnemyController(_data));
        }

        private void Update()
        {
            foreach (var item in _controllers)
                item.Updater();
        }
    }


}
