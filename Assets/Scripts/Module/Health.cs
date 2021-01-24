namespace Asteroids
{
    public sealed class Health
    {
        public float Max { get; private set; }
        public float Current { get; private set; }

        /// <summary>
        /// Полный конструктор класса Health
        /// </summary>
        /// <param name="max">Максимальное здоровье</param>
        /// <param name="current">Текущее здоровье</param>
        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }

        /// <summary>
        /// Упрощённый конструктор класса Health, где текущее здоровье равняется максимальному
        /// </summary>
        /// <param name="max">Максимальное здоровье</param>
        public Health(float max) : this(max, max)
        {
        }

        /// <summary>
        /// Изменение текущего здоровья
        /// </summary>
        /// <param name="hp">Целевое значение здоровья</param>
        public void ChangeCurrentHealth(float hp) => Current = hp;
    }
}