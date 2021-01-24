﻿using UnityEngine;
using static UnityEngine.Random;
using static Asteroids.NameManager;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour, IEnemyMove, IRotation
    {
        private static float _minPositionOffset = 1f;
        private static float _maxPositionOffset = 5f;

        private IEnemyMove _moveImplementation;
        private IRotation _rotationImplementation;

        private Transform _rotPool;
        private Health _health;
        private float _speed;
        public float Speed { get => _speed; private set => _speed = value; }

        public Health Health
        {
            get
            {
                if (_health.Current <= 0f)
                    ReturnToPool();

                return _health;
            }
            protected set => _health = value;
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }
                return _rotPool;
            }
        }

        private void Start()
        {

        }

        private float RandomSpeed()
        {
            var speed = Range(0.05f, 1f);
            _speed = speed;
            return speed;
        }

        /// <summary>
        /// Активация врага
        /// </summary>
        /// <param name="position">Позиция активации</param>
        /// <param name="rotation">Кватернион активации</param>
        public void ActivateEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
            _moveImplementation = new MoveTransform(transform, RandomSpeed());
            _rotationImplementation = new RotationShip(transform);
        }

        /// <summary>
        /// Активация врага
        /// </summary>
        /// <param name="position">Позиция активации активации</param>
        public void ActivateEnemy(Vector3 position)
        {
            transform.localPosition = position;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(true);
            transform.SetParent(null);
            _moveImplementation = new MoveTransform(transform, RandomSpeed());
            _rotationImplementation = new RotationShip(transform);
            Health = new Health(100f);
        }

        /// <summary>
        /// Возврат объекта в пул
        /// </summary>
        public void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);

            if (!RotPool)
                Destroy(gameObject);
        }

        /// <summary>
        /// Создание врага-астероида
        /// </summary>
        /// <param name="hp">Здоровье врага</param>
        /// <returns></returns>
        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Prefabs/Asteroid"));
            enemy.Health = hp;
            return enemy;
        }

        /// <summary>
        /// Создание врага-астероида в случайном месте рядом с заданной позицией
        /// </summary>
        /// <param name="hp">Здоровье врага</param>
        /// <param name="position">Исходная позиция</param>
        /// <returns>Астероид</returns>
        public static Asteroid CreateAsteroidEnemy(Health hp, Vector3 position)
        {
            Vector3 desirePosition = RandomPosition(position);
            var enemy = Instantiate(
                Resources.Load<Asteroid>("Prefabs/Asteroid"), desirePosition, Quaternion.identity);
            enemy.Health = hp;
            return enemy;
        }

        /// <summary>
        /// Выбор случайной позиции, рядом с выбранными координатами
        /// </summary>
        /// <param name="position">Исходная позиция</param>
        /// <returns>Случайная точка недалеко от исходной позиции</returns>
        public static Vector3 RandomPosition(Vector3 position)
        {
            bool flag = true;
            var result = new Vector3();
            do
            {
                var minPosX = position.x - _maxPositionOffset;
                var maxPosX = position.x + _maxPositionOffset;
                var minPosY = position.y - _maxPositionOffset;
                var maxPosY = position.y + _maxPositionOffset;
                var posX = Range(minPosX, maxPosX);
                var posY = Range(minPosY, maxPosY);
                if ((posX > _minPositionOffset || posX < -_minPositionOffset) ||
                    (posY > _minPositionOffset && posY < -_minPositionOffset))
                {
                    result.x = posX;
                    result.y = posY;
                    flag = false;
                }
            }
            while (flag);
            return result;
        }

        /// <summary>
        /// Внедрение зависимости для здоровья
        /// </summary>
        /// <param name="hp">Здоровье</param>
        public void DepedencyInjectHealth(Health hp) => Health = hp;

        /// <summary>
        /// Движение врагов
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        /// <param name="deltaTime"></param>
        public void MoveEnemy(Vector3 direction, float deltaTime)
        {
            _moveImplementation.MoveEnemy(direction, deltaTime);
        }

        /// <summary>
        /// Поворот врага
        /// </summary>
        /// <param name="direction"></param>
        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

    }
}
