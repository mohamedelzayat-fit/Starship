using Starship.Core.Entities;
using Starship.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Starship.Core.Generators
{
    public class EnemyGenerator : TrackedEntity
    {
        [SerializeField]
        private float GenerationSpeed;

        [SerializeField]
        private GameMetrics GameBoundaries;

        [SerializeField]
        private float TopOffset;
        
        private ObjectPool EnemiesPool { get; set; }

        private float NextEnemy { get; set; } = 0;
        
        
        private void Start()
        {
            EnemiesPool = this.GetComponent<ObjectPool>();
        }

        private void Update()
        {
            if (Time.time > NextEnemy)
            {
                NextEnemy = Time.time + GenerationSpeed;
                EnemiesPool.InstantiateObject(
                    new Vector3(
                        Random.Range(GameBoundaries.LimitLeft, GameBoundaries.LimitRight), 
                        0, 
                        GameBoundaries.LimitUp + TopOffset));
            }
        }
    }
}