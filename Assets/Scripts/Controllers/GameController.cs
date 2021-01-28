using System.Collections.Generic;
using UnityEngine;
using Asteroids.Object_Pool;


namespace Asteroids
{
    class GameController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private float _asteroidSpeed;


        private List<IController> _controllers = new List<IController>();
        private Ship _ship;
        private Rigidbody2D _rigidbody;

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

            _controllers.Add(_cameraController);
            _controllers.Add(new PlayerController(_player));
            _controllers.Add(new InputController(_player, _ship, _player, _rigidbody));
            _controllers.Add(new EnemyController(new EnemyPool(5), _player));
        }

        private void Update()
        {
            foreach (var item in _controllers)
                item.Updater();
        }
    }


}
