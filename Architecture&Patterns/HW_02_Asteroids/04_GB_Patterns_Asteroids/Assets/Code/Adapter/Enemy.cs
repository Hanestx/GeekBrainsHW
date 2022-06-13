using UnityEngine;

namespace Asteroids.Adapter
{
    public class Enemy : IFire
    {
        private readonly IAttack _attack = new AttackBullet();
        
        public void Fire(Vector3 position)
        {
            _attack.Attack(position);
        }
    }
}