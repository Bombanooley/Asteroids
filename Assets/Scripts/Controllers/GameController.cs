using System.Collections.Generic;
using UnityEngine;


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
        }

        private void Update()
        {
            foreach (var item in _controllers)
                item.Updater();
        }
    }


}
