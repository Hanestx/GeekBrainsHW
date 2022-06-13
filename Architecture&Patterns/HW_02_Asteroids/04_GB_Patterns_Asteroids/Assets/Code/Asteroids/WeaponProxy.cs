using UnityEngine;

namespace Asteroids
{
    internal sealed class WeaponProxy : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly UnlockWeapon _unlockWeapon;
        public float Force { get; }
        
        
        public WeaponProxy(IWeapon weapon, UnlockWeapon unlockWeapon)
        {
            _weapon = weapon;
            _unlockWeapon = unlockWeapon;
        }
        
        public void Shoot()
        {
            if (_unlockWeapon.IsUnlock)
            {
                _weapon.Shoot();
            }
            else
            {
                Debug.Log("Weapon is lock");
            }
        }

        public void UnlockWeapon()
        {
            _unlockWeapon.IsUnlock = !_unlockWeapon.IsUnlock;
        }
    }
}