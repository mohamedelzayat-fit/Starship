using Starship.Core.Entities;
using Starship.Managers;
using Starship.ScriptableObjects;
using Starship.ScriptableObjects.Generators;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Starship.Core.Generators
{
    public class EnemyGenerator : TrackedEntity // Generator Processor
    {
        // [SerializeField]
        // private Generator Generator;
        
        private ObjectPool EnemiesPool { get; set; }

        private float TimeForNextEnemy { get; set; } = 0;

        private GameManager GameManagment;

        private WaveProcessor WProcessor { get; set; }
        
        private Wave CurrentWave { get; set; }

        private void Start()
        {
            WProcessor = this.GetComponent<WaveProcessor>();
            WProcessor.OnWaveChanged += WProcessorOnOnWaveChanged;
            GameManagment = this.GetComponent<GameManager>();
        }

        private void WProcessorOnOnWaveChanged(Wave wave)
        {
            CurrentWave = wave;
        }

        private void GenerateObject()
        {
            if(ReferenceEquals(CurrentWave?.Generator, null)) return;
            
            if (!(Time.time > CurrentWave.Generator.GenerationRate)) return;
            
            var NextEnemy = CurrentWave.Generator.GetNextItem();

            if (ReferenceEquals(NextEnemy, null)) return;
            
            TimeForNextEnemy = Time.time + CurrentWave.Generator.GenerationRate;
            var GeneratedEnemy = Instantiate(NextEnemy);
            GeneratedEnemy.transform.position =  new Vector3(
                Random.Range(CurrentWave.Generator.Metrics.LimitLeft, CurrentWave.Generator.Metrics.LimitRight), 
                0, 
                CurrentWave.Generator.Metrics.LimitUp) + CurrentWave.Generator.InstantiationOffset;

            GameManagment.AddTrackedEntity(GeneratedEnemy.GetComponent<TrackedEntity>());
        }
        
        private void Update()
        {
            GenerateObject();
        }
    }
}