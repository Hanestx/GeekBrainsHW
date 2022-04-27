using UnityEngine;
using System.Collections.Generic;


namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private float _force;
        [SerializeField] private float _acceleration;
        [SerializeField] private List<Rigidbody2D> _bullets;
        [SerializeField] private Transform _barrel;

        private Camera _camera;
        private Ship _ship;
        private Health _health;
        private IWeapon _gunBall;
        private InputManager _inputManager;


        private void Start()
        {
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            
            _camera = Camera.main;
            _health = new Health(_hp, _hp);
            _gunBall = new GunBall(_bullets, _force, _barrel);
            _ship = new Ship(moveTransform, rotation, _gunBall, _health);
            _inputManager = new InputManager(_ship, _camera, transform);
        }

        private void Update()
        {
            _inputManager.Update();
        }

        private void OnCollisionEnter2D(Collision2D other) //Вынести отсюда
        {
            _ship.GetDamage();
        }
    }
}
