using UnityEngine;


namespace Code.Json
{
    internal sealed class InfantryFactory : IUnitFactory
    {
        public Unit Create(string type, Health hp)
        {
            var unit = Object.Instantiate(Resources.Load<Infantry>("Unit/Infantry"));
            unit.DependencyInjectType(type);
            unit.DependencyInjectHealth(hp);
            return unit;
        }
    }
}