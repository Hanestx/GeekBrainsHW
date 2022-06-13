using UnityEngine;

namespace Asteroids.Decorator
{
    public interface IAim
    {
        GameObject AimInstance { get; }
        public Transform BarrelPositionAim { get; }
    }
}