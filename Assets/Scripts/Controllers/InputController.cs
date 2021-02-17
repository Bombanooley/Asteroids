using UnityEngine;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class InputController :  IController
    {
        private readonly IAttack _attack;
        private readonly Ship _ship;
        private readonly Player _player;
        private readonly Camera _camera;
        private readonly Rigidbody2D _rigidbody;

        public Vector3 direction;

        public InputController(Data data)
        {
            _attack = data.Player;
            _ship = data.Ship;
            _player = data.Player;
            _camera = Camera.main;
            _rigidbody = data.Rigidbody;
        }

        public void Updater()
        {
            direction = _camera.ScreenToWorldPoint(Input.mousePosition) - _player.transform.position;
            _ship.Rotation(direction);


            direction.x = Input.GetAxis(HORIZONTAL);
            direction.y = Input.GetAxis(VERTICAL);
            if (direction.sqrMagnitude > 0)
            _ship.Move(direction.x, direction.y, Time.deltaTime, _rigidbody);

            if (Input.GetButtonDown(FIRE1))
                _attack.Attack();

            if (Input.GetKeyDown(ACCELERATION))
                _ship.AddAcceleration();

            if (Input.GetKeyUp(ACCELERATION))
                _ship.RemoveAcceleration();
        }
    }
}
