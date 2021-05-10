using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

namespace Starship.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Starship/Ships/Ship attribute", fileName = "ShipAttribute")]
    public class ShipAttribute : ScriptableObject
    {
        [Range(0.001f, 100)]
        public float FireRate;

        [Range(0.01f, 30f)]
        public float ShipSpeed;
    }
}