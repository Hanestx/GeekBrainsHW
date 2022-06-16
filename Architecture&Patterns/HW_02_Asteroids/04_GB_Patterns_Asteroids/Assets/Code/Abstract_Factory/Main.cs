using UnityEngine;

namespace Asteroids.Abstract_Factory
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            var platform = new PlatformFactory().Create(Application.platform);
        }
    }
}