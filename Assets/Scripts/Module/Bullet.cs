using UnityEngine;
using static Asteroids.NameManager;


namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(ENEMY))
            {
                Debug.Log("Bullet hit");
                Destroy(gameObject);
                collision.gameObject.GetComponent<Enemy>().ReturnToPool();
            }
        }
    }
}