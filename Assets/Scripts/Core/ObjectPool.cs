using System.Collections.Generic;
using Starship.Core.Entities;
using UnityEngine;

namespace Starship.Core
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField]
        public Transform ParentTransform;

        [SerializeField]
        private GameObject Prefab;

        [SerializeField]
        private int PoolSize;

        public List<GameObject> Prefabs { get; set; }
        
        private int Index { get; set; } = 0;
        
        private void Awake()
        {
            Prefabs = new List<GameObject>();
            for (int i = 0; i < PoolSize; i++)
            {
                Prefabs.Add(Instantiate(Prefab, ParentTransform));
            }
        }

        public void InstantiateObject(Vector3 position)
        {
            var PooledObject = Prefabs[Index++ % Prefabs.Count];
            if (!PooledObject.activeInHierarchy)
            {
                PooledObject.SetActive(true);
                PooledObject.transform.position = position;
            }
        }
    }
}