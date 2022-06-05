using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed  class Aim : IAim
    {
        public GameObject AimInstance { get; }
        public Transform BarrelPositionAim { get; }

        public Aim(GameObject aimInstance, Transform barrelPositionAim)
        {
            AimInstance = aimInstance;
            BarrelPositionAim = barrelPositionAim;
        }
    }
}