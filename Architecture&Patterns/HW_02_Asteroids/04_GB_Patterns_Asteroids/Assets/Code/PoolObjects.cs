using System;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class PoolMono 
        {
            private List<Rigidbody2D> _pool;
            
            
            public PoolMono(List<Rigidbody2D> prefabs)
            {
                _pool = prefabs;
            }

            public bool HasFreeElement(out Rigidbody2D element)
            {
                foreach (var mono in _pool)
                {
                    if (!mono.gameObject.activeInHierarchy)
                    {
                        element = mono;
                        mono.gameObject.SetActive(true);
                        return true;
                    }
                }
                
                DisabledActiveElements();
                element = GetFreeElement();
                return true;
            }

            public Rigidbody2D GetFreeElement()
            {
                if (HasFreeElement(out var element))
                {
                    return element;
                }
                
                throw new Exception($"There is no free elements in pool of type {typeof(GameObject)}");
            }

            public void DisabledActiveElements()
            {
                foreach (var mono in _pool)
                {
                    if (mono.gameObject.activeInHierarchy)
                        mono.gameObject.SetActive(false);
                }
            }
        }
    }