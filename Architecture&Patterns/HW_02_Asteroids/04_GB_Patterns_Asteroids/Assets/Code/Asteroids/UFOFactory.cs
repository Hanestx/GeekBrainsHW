using UnityEngine;

namespace Asteroids
{
    internal sealed class UFOFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<UFO>("Enemy/UFO"));

            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}