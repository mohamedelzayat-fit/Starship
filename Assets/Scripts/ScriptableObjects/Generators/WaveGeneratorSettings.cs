using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Starship.ScriptableObjects.Generators
{
    [CreateAssetMenu(fileName = "WaveSettings", menuName = "Starship/Generators/Wave Settings")]
    public class WaveGeneratorSettings : ScriptableObject
    {
        [ReorderableList]
        public List<Wave> Waves;
        private int Count = 0;
        
        private void OnEnable() => Count = 0;

        public Wave GetNextWave() => Waves[Count++ % Waves.Count];
    }
}