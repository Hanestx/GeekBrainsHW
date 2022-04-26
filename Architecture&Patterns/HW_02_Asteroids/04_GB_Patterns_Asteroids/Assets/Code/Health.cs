using UnityEngine;


namespace Asteroids
{
    internal sealed class Health : IDamage
    {
        public float HP { get; private set; }
        private GameObject _player;

        
        public Health(float hp, GameObject player)
        {
            HP  = hp;
            _player = player;
        }
        
        public void GetDamage()
        {
            HP--;
            if (HP <= 0)
            {
               _player.SetActive(false);
            }
            
            Debug.Log(HP);
        }
        
        public void AddHealth()
        {
            HP++;
            Debug.Log(HP);
        }
    }
}