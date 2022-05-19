using UnityEngine;
using System.Collections.Generic;
using Asteroids.ObjectPool;


namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private float _force;
        [SerializeField] private float _acceleration;
        [SerializeField] private Transform _barrel;

        private Camera _camera;
        private CameraController _cameraController;
        private Ship _ship;
        private Health _health;
        private IWeapon _gunBall;
        private InputManager _inputManager;


        private void Start()
        {
            PoolMono<Bullet> _bulletsPool = new PoolMono<Bullet>(Resources.Load<Bullet>("Ammo/Bullet"), 10, true, new
                GameObject(NameManager.POOL_AMMUNITION).transform);
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            
            _camera = Camera.main;
            _health = new Health(_hp, _hp);
            _gunBall = new GunBall(_force, _barrel, _bulletsPool);
            _ship = new Ship(moveTransform, rotation, _gunBall, _health);
            _inputManager = new InputManager(_ship, _camera, transform);
            _cameraController = new CameraController(_camera, transform);
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
