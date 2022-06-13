using System;

namespace Code.NullObject.FirstExample.Observer
{
    public interface IHit
    {
        event Action<float> OnHitChange;
        void Hit(float damage);
    }
}