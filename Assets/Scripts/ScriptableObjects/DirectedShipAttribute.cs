using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starship.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Starship/Ships/Directed ship attribute", fileName = "DirectedShipAttribute")]
    public class DirectedShipAttribute : ShipAttribute
    {
        public Vector3 TravelingDirection;
    }
}