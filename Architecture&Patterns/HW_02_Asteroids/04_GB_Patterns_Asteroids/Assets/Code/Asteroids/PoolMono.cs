using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Asteroids
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        private T _prefab;
        private bool _autoExpand;
        private Transform _container;
        private List<T> _pool;

        public PoolMono(T prefab, int count, bool autoExpand) : this(prefab, count, autoExpand, null) { }
        public PoolMono(T prefab, int count, bool autoExpand, Transform container)
        {
            _prefab = prefab;
            _container = container;
            _autoExpand = autoExpand;
            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
                CreateObject();
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(_prefab, _container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }
        
        public bool HasFreeElement(out T element)
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

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            if (_autoExpand)
                return CreateObject(true);

            throw new Exception($"There is no free elements in pool of type {typeof(T)}");
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