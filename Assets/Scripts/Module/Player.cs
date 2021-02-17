﻿using UnityEngine;
using static Asteroids.NameManager;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : MonoBehaviour, IAttack, IExecute
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private float _bulletLifeSpam;
        [SerializeField] private OutOfDisplayCheker _outOfDisplayCheker;
        private Rigidbody2D _rigidbody;

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
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Attack()
        {
            var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
            Destroy(temAmmunition.gameObject, _bulletLifeSpam);

        }

        public void Execute()
        {
            if (_hp <= 0)
                Time.timeScale = 0f;

            var direction = _camera.ScreenToWorldPoint(Input.mousePosition);

            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime, _rigidbody);

            _outOfDisplayCheker.transform.position = transform.position;
        }

        public void InitializeShip(ref Ship ship)
        {
            var moveTransform = new AccelerationMove(transform, _rigidbody, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            ship = new Ship(moveTransform, rotation, _rigidbody);
            _ship = ship;

        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(ENEMY))
            {
                    _hp -= 50f;
                    Debug.Log($"Hit {_hp}");
                    
            }
        }
    }
}

