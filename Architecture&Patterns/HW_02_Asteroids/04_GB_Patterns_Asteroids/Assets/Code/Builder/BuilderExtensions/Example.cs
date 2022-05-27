using UnityEngine;

namespace Asteroids.Builder.BuilderExtensions
{
    internal sealed class Example : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;
        private void Start()
        {
            new GameObject().SetName("Enemy").AddBoxCollider2D().AddBoxCollider2D().AddRigidbody2D(5.0f).AddSprite(_sprite);
        }
    }
}