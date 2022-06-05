using UnityEngine;


namespace Code.Json
{
    internal class MagFactory : IUnitFactory
    {
        public Unit Create(string type, Health hp)
        {
            var unit = Object.Instantiate(Resources.Load<Mag>("Unit/Mag"));
            unit.DependencyInjectType(type);
            unit.DependencyInjectHealth(hp);
            return unit;
        }
    }
}