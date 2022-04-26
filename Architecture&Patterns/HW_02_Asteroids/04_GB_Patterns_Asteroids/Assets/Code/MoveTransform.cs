using UnityEngine;


namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        public float Speed { get; protected set; }
        private Vector3 _move;

        
        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * Speed, 0.0f);
            _transform.localPosition += _move;
        }
    }
}