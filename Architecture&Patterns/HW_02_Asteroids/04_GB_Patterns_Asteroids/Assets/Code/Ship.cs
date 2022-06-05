using UnityEngine;


namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation, IDamage
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly IWeapon _weaponImplementation;
        private readonly IDamage _damageImplementation;
        public float Speed => _moveImplementation.Speed;

        
        public Ship(IMove moveImplementation, IRotation rotationImplementation, IWeapon weaponImplementation, IDamage damageImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _weaponImplementation = weaponImplementation;
            _damageImplementation = damageImplementation;
        }
        
        public void UnlockWeapon()
        {
            if (_weaponImplementation is WeaponProxy _weapon)
            {
                _weapon.UnlockWeapon();
            }
        }
        
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }
        
        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }
        
        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        public void Shoot()
        {
            _weaponImplementation.Shoot();
        }

        public void GetDamage()
        {
            _damageImplementation.GetDamage();
        }

        

    }
}