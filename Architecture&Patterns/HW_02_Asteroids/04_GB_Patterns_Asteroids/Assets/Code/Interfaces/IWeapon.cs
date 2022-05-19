using UnityEngine;

namespace Asteroids
{
    public interface IWeapon
    {
        float Force { get; }

        void Shoot();
    }
}