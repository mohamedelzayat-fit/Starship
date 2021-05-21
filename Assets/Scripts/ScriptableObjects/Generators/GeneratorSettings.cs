using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starship.ScriptableObjects.Generators
{
    [CreateAssetMenu(fileName = "GeneratorSettings", menuName = "Starship/Generators/Generator Settings", order = 1)]
    public class GeneratorSettings : ScriptableObject
    {
        public GameObject ObjectToGenerate;
        [Range(1, 100)]
        public int NumberOfOccurrences;
    }
}