using UnityEngine;


namespace Asteroids
{
    internal sealed class InputManager
    {
        private readonly Ship _ship;
        private readonly Camera _camera;
        private readonly Transform _transform;

        
        public InputManager(Ship ship, Camera camera, Transform transform)
        {
            _ship = ship;
            _camera = camera;
            _transform = transform;
        }

        public void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _ship.Shoot();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                _ship.UnlockWeapon();
            }
        }
    }
}