using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Asteroids
{
    public class CameraController
    {
        private Camera _camera;
        private Transform _player;
        private Vector3 _offset = new Vector3(0,0,-10);
        
        
        public CameraController(Camera camera, Transform player)
        {
            _camera = camera;
            _player = player;
        }

        public void Update()
        {
            _camera.transform.position = _player.position + _offset;
        }
    }
}