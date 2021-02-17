using UnityEngine;
using static Asteroids.NameManager;

namespace Asteroids
{
    public class OutOfDisplayCheker : MonoBehaviour, IExecute
    {
        [SerializeField] private Transform _player;
        public OutOfDisplayCheker(Transform player)
        {
            _player = player;
        }

        public void Execute()
        {
            transform.position = _player.position;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {

            if (collision.gameObject.CompareTag(ENEMY))
                collision.GetComponent<Enemy>().ReturnToPool();
        }
    }
}
