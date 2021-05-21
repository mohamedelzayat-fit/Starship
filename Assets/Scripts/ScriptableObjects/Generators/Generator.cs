using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Starship.Core.Generators;
using UnityEngine;

namespace Starship.ScriptableObjects.Generators
{
    [CreateAssetMenu(fileName = "Generator", menuName = "Starship/Generators/Generator", order = 1)]
    public class Generator : ScriptableObject
    {
        [BoxGroup("Generator assets")]
        [SerializeField]
        private List<GeneratorSettings> GeneratorSettings;

        [BoxGroup("Generator setup")]
        [SerializeField]
        public float GenerationRate;

        [BoxGroup("Generator setup")]
        [SerializeField]
        public GameMetrics Metrics;

        [BoxGroup("Generator setup")]
        [SerializeField]
        public Vector3 InstantiationOffset;

        private ShuffleBag<GameObject> ObjectsShufflebag { get; set; }

        private void OnEnable()
        {
            ObjectsShufflebag = new ShuffleBag<GameObject>();
            
            if (!ReferenceEquals(GeneratorSettings, null))
            {
                foreach (var item in GeneratorSettings)
                {
                    ObjectsShufflebag.Add(item.ObjectToGenerate, item.NumberOfOccurrences);
                }
            }
        }

        private void OnDisable() => ObjectsShufflebag = null;
        
        public GameObject GetNextItem() => ObjectsShufflebag.Next();
    }
}