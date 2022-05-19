using Asteroids.ObjectPool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        public Bullet _Bullet;

        private void Start()
        { 
            Enemy.CreateAsteroidEnemy(new Health(1.0f, 1.0f));
            Enemy.CreateUFOEnemy(new Health(10.0f, 10.0f));
            
            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));

            IEnemyFactory factoryUFO = new UFOFactory();
            factoryUFO.Create(new Health(100.0f, 100.0f));

            Enemy.Factory = factory;
            Enemy.Factory.Create(new Health(100.0f, 100.0f));
            
            //Pool Object
            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);

           // PoolMono<Bullet> _bulletsPool = new PoolMono<Bullet>(_Bullet, 10, true);
        }
    }
}