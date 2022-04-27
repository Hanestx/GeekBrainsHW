using UnityEngine;


namespace Asteroids
{
    internal sealed class Health : IDamage
    {
        public float Max { get; }
        public float Current { get; private set; }
        private GameObject _player;

        
        public Health(float max, float current)
        {
            Max = max;
            Current  = current;
        }

        public void GetDamage()
        {
            Current--;
            if (Current <= 0)
            {
               _player.SetActive(false);
            }
            
            Debug.Log(Current);
        }
        
        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
            Debug.Log(Current);
        }
    }
}