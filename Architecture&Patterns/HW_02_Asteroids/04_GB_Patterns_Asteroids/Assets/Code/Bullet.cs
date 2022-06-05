using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D coll)
        {
            if(coll.CompareTag("Asteroid"))
            {
                coll.transform.GetComponent<Asteroid>().DestroyAsteroid();
                gameObject.SetActive(false);
            }
        }
        void OnBecameInvisible() 
        {
            gameObject.SetActive(false);
        }
    }
}