using UnityEngine;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class InputController : MonoBehaviour, IController
    {
        private readonly IAttack _attack;
        private readonly Ship _ship;
        private readonly Player _player;
        private readonly Camera _camera;

        public Vector3 direction;

        public InputController(IAttack attack, Ship ship, Player player)
        {
            _attack = attack;
            _ship = ship;
            _player = player;
            _camera = Camera.main;
        }

        public void Updater()
        {
            direction = _camera.ScreenToWorldPoint(Input.mousePosition) - _player.transform.position;
            _ship.Rotation(direction);



            _ship.Move(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL), Time.deltaTime);

            if (Input.GetButtonDown(FIRE1))
                _attack.Attack();

            if (Input.GetKeyDown(ACCELERATION))
                _ship.AddAcceleration();

            if (Input.GetKeyUp(ACCELERATION))
                _ship.RemoveAcceleration();
        }
    }
}
