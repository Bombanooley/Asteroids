using UnityEngine;

namespace Asteroids
{
    public sealed class Player : MonoBehaviour, IAttack, IExecute
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private float _bulletLifeSpam;

        private Camera _camera;
        private Ship _ship;

        public float Speed { get => _speed; set => _speed = value; }
        public float Acceleration { get => _acceleration; set => _acceleration = value; }
        public float Hp { get => _hp; set => _hp = value; }
        public Transform Barrel { get => _barrel; set => _barrel = value; }
        public float Force { get => _force; set => _force = value; }
        public Ship Ship { get => _ship; set => _ship = value; }

        private void Start()
        {
            _camera = Camera.main;
        }

        public void Attack()
        {
            var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
            Destroy(temAmmunition.gameObject, _bulletLifeSpam);
        }

        public void Execute()
        {
            var direction = _camera.ScreenToWorldPoint(Input.mousePosition);

            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);
        }

        public void InitializeShip()
        {
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);

        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
                Destroy(gameObject);
            else
                _hp--;
        }

    }
}

