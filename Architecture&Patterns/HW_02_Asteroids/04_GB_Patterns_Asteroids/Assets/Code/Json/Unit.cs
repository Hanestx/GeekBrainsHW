using UnityEngine;


namespace Code.Json
{
    internal abstract class Unit : MonoBehaviour
    {
        private Health _health;
        [SerializeField] private string _type;
        public static IUnitFactory Factory;
        
        public void DependencyInjectHealth(Health hp)
        {
            _health = hp;
        }
        
        public void DependencyInjectType(string type)
        {
            _type = type;
        }

        public override string ToString()
        {
            return $"Type: {_type}   Hp: {_health.GetHealth()}";
        }
    }
}