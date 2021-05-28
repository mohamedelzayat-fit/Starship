using System;
using Starship.ScriptableObjects.Generators;
using UnityEngine;

namespace Starship.Core.Generators
{
    public class WaveProcessor : MonoBehaviour
    {
        [SerializeField]
        private WaveGeneratorSettings WaveSettings;

        public event Action<Wave> OnWaveChanged;

        private float TimeForNextWave = 0.0f;
        
        private void Update()
        {
            if (Time.time > TimeForNextWave)
            {
                var NextWave = WaveSettings.GetNextWave();
                TimeForNextWave = Time.time + NextWave.Duration;
                OnWaveChanged?.Invoke(NextWave);
            }
        }
    }
}