using UnityEngine;


namespace Asteroids
{
    internal sealed class Asteroid : Enemy
    {
        public int speed = 5;
        public Rigidbody2D[] _asteroids;
        public Transform[] _points;
        public int ID = 0;
        private bool start = false;
        private Rigidbody2D _asteroid;

        public void DestroyAsteroid()
        {
            if (ID == 2) Destroy(gameObject);
            if (ID == 0)
            {
                _asteroid = Instantiate(_asteroids[Random.Range(0, _asteroids.Length)], _points[0].position,
                    Quaternion.identity) as Rigidbody2D;
                _asteroid.velocity = _points[0].TransformDirection(Vector2.right * speed);
                _asteroid.GetComponent<Asteroid>().ID = 1;
                _asteroid.GetComponent<Asteroid>()._asteroids = _asteroids;
                _asteroid.transform.localScale =
                    new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, 1);

                _asteroid = Instantiate(_asteroids[Random.Range(0, _asteroids.Length)], _points[1].position,
                    Quaternion.identity) as Rigidbody2D;
                _asteroid.velocity = _points[1].TransformDirection(Vector2.right * speed);
                _asteroid.GetComponent<Asteroid>().ID = 1;
                _asteroid.GetComponent<Asteroid>()._asteroids = _asteroids;
                _asteroid.transform.localScale =
                    new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, 1);

                _asteroid = Instantiate(_asteroids[Random.Range(0, _asteroids.Length)], _points[2].position,
                    Quaternion.identity) as Rigidbody2D;
                _asteroid.velocity = _points[2].TransformDirection(Vector2.right * speed);
                _asteroid.GetComponent<Asteroid>().ID = 1;
                _asteroid.GetComponent<Asteroid>()._asteroids = _asteroids;
                _asteroid.transform.localScale =
                    new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, 1);

                Destroy(gameObject);
            }

            if (ID == 1)
            {
                _asteroid = Instantiate(_asteroids[Random.Range(0, _asteroids.Length)], _points[0].position,
                    Quaternion.identity) as Rigidbody2D;
                _asteroid.velocity = _points[0].TransformDirection(Vector2.right * speed);
                _asteroid.GetComponent<Asteroid>().ID = 2;
                _asteroid.GetComponent<Asteroid>()._asteroids = _asteroids;
                _asteroid.transform.localScale =
                    new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, 1);

                _asteroid = Instantiate(_asteroids[Random.Range(0, _asteroids.Length)], _points[1].position,
                    Quaternion.identity) as Rigidbody2D;
                _asteroid.velocity = _points[1].TransformDirection(Vector2.right * speed);
                _asteroid.GetComponent<Asteroid>().ID = 2;
                _asteroid.GetComponent<Asteroid>()._asteroids = _asteroids;
                _asteroid.transform.localScale =
                    new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, 1);

                Destroy(gameObject);
            }
            
            void OnBecameVisible() 
            {
                start = true;
            }

            void OnBecameInvisible() 
            {
                if(start)
                    Destroy (gameObject);
            }
        }
    }
}