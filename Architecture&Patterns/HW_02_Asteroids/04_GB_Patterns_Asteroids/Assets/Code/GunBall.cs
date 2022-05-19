using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal sealed class GunBall : IWeapon
    {
        public float Force { get; }
        private PoolMono<Bullet> _poolBullets;
        private Bullet _bullet;
        private Transform _barrel;
        

        public GunBall(float force, Transform barrel, PoolMono<Bullet> pool)
        {
            _poolBullets = pool;
            Force = force;
            _barrel = barrel;
        }
        
        public void Shoot()
        {
            _bullet = _poolBullets.GetFreeElement();
            _bullet.gameObject.transform.position = _barrel.transform.position;
            _bullet.gameObject.transform.rotation = _barrel.rotation;
            _bullet.GetComponent<Rigidbody2D>().AddForce(_barrel.up * Force);
        }
    }
}