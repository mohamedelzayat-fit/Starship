using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starship.ScriptableObjects.Generators
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Starship/Generators/Wave")]
    public class Wave : ScriptableObject
    {
        public string Name;
        public Generator Generator;

        [Range(0.1f, 200)]
        [Tooltip("Duration in seconds")]
        public float Duration;
    }
}