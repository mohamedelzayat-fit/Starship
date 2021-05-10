using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starship.ScriptableObjects
{
    public abstract class MovingEffect : BaseEffect
    {
        [Range(0.01f, 50)]
        public float TravelingSpeed;
        public Vector3 TravelingDirection;
    }
}