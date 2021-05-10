using System.Collections;
using System.Collections.Generic;
using Starship.Core.Entities;
using UnityEngine;

namespace Starship.ScriptableObjects
{
    public class HealthEffect : MovingEffect
    {
        [SerializeField]
        private float Amount;
        
        public override void ApplyEffect(TrackedEntity trackedEntity)
        {
            trackedEntity.Health += Amount;
        }
    }
}