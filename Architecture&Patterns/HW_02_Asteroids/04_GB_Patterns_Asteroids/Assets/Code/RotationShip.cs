using UnityEngine;

namespace Asteroids
{
    public class RotationShip :IRotation
    {
        private Transform _transform;

        public RotationShip(Transform transform)
        {
            _transform = transform;
        }
        
        public void Rotation(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            _transform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}