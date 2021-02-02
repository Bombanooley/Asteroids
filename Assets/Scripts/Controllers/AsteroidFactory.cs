using UnityEngine;
using static UnityEngine.Random;


namespace Asteroids
{
    public class AsteroidFactory : IEnemyFactory
    {
        private float _minPositionOffset = 1f;
        private float _maxPositionOffset = 5f;

        /// <summary>
        /// Создание врага-астероида
        /// </summary>
        /// <param name="hp">Здоровье врага</param>
        /// <returns></returns>
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Prefabs/Asteroid"));

            enemy.DepedencyInjectHealth(hp);
            
            return enemy;
        }

        /// <summary>
        /// Создание врага-астероида в случайном месте рядом с заданной позицией
        /// </summary>
        /// <param name="hp">Здоровье врага</param>
        /// <param name="position">Исходная позиция</param>
        /// <returns>Астероид</returns>
        public Enemy Create(Health hp, Vector3 position)
        {
            Vector3 desirePosition = RandomPosition(position);
            var enemy = Object.Instantiate(
                Resources.Load<Asteroid>("Prefabs/Asteroid"), desirePosition, Quaternion.identity);
            enemy.DepedencyInjectHealth(hp);
            
            return enemy;
        }

        /// <summary>
        /// Выбор случайной позиции, рядом с выбранными координатами
        /// </summary>
        /// <param name="position">Исходная позиция</param>
        /// <returns>Случайная точка недалеко от исходной позиции</returns>
        private Vector3 RandomPosition(Vector3 position)
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
    }
}
