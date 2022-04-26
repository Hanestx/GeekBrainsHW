using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal sealed class GunBall : IWeapon
    {
        public float Force { get; }
        private PoolMono _poolBullets;
        private Rigidbody2D _bullet;
        private Transform _barrel;
        

        public GunBall(List<Rigidbody2D> bullets,  float force, Transform barrel)
        {
            _poolBullets = new PoolMono(bullets);
            Force = force;
            _barrel = barrel;
        }
        
        public void Shoot()
        {
            _bullet = _poolBullets.GetFreeElement();
            _bullet.gameObject.transform.position = _barrel.transform.position;
            _bullet.gameObject.transform.rotation = _barrel.rotation;
            _bullet.AddForce(_barrel.up * Force);
        }
    }
}