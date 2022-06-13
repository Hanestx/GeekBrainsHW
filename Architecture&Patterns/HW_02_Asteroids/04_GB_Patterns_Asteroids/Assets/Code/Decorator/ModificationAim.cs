using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class ModificationAim : ModificationWeapon
    {
        private readonly IAim _aim;
        private readonly Vector3 _aimPosition;
        private GameObject aim;

        public ModificationAim(IAim prefab, Vector3 aimPosition)
        {
            _aim = prefab;
            _aimPosition = aimPosition;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            if (aim)
            {
                aim.SetActive(true);
                return weapon;
            }
            
            aim = Object.Instantiate(_aim.AimInstance, _aimPosition, Quaternion.identity);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            if (aim)
            {
                aim.SetActive(false);
                return weapon;
            }

            return weapon;
        }
    }
}