using System;
using UnityEngine;


namespace Code.NullObject.FirstExample.Observer
{
    public sealed class Enemy : MonoBehaviour, IHit
    {
        public event Action<float> OnHitChange = delegate(float f) { };
        
        public void Hit(float damage)
        {
            OnHitChange.Invoke(damage);
        }
    }
}