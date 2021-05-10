using System.Collections;
using System.Collections.Generic;
using Starship.Core.Entities;
using UnityEngine;

namespace Starship.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Starship/Projectiles", fileName = "Projectile")]
    public class Projectile : MovingEffect
    {
        [SerializeField]
        private float Damage;
        
        public override void ApplyEffect(TrackedEntity trackedEntity)
        {
            trackedEntity.Health -= Damage;
        }
    }
}