using UnityEngine;

namespace Starship.Core.Entities
{
    public class TrackedEntity : MonoBehaviour
    {
        public bool IsPaused { get; set; }
        public float Health { get; set; } = 100;
    }
}