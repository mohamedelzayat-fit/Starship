using Starship.Core.Entities;
using Starship.Managers;
using Starship.ScriptableObjects;
using Starship.ScriptableObjects.Generators;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Starship.Core.Generators
{
    public class EnemyGenerator : TrackedEntity
    {
        [SerializeField]
        private Generator Generator;
        
        private ObjectPool EnemiesPool { get; set; }

        private float NextEnemy { get; set; } = 0;

        private GameManager GameManagment;
        
        private void Start()
        {
            EnemiesPool = this.GetComponent<ObjectPool>();
            GameManagment = this.GetComponent<GameManager>();
            
            for (int i = 0; i < EnemiesPool.Prefabs.Count; i++)
            {
                GameManagment.AddTrackedEntity(EnemiesPool.Prefabs[i].GetComponent<TrackedEntity>());
            }
        }

        private void Update()
        {
            if (Time.time > NextEnemy)
            {
                NextEnemy = Time.time + Generator.GenerationRate;
                EnemiesPool.InstantiateObject(
                    new Vector3(
                        Random.Range(Generator.Metrics.LimitLeft, Generator.Metrics.LimitRight), 
                        0, 
                        Generator.Metrics.LimitUp) + Generator.InstantiationOffset);
            }
        }
    }
}