using NaughtyAttributes;
using UnityEngine;

namespace Starship.Controllers.Player
{
    public class StarshipAnimationController : MonoBehaviour
    {
        private static readonly int BarrelRollRight = Animator.StringToHash("TriggerBarrelRollRight");
        private static readonly int BarrelRollLeft = Animator.StringToHash("TriggerBarrelRollLeft");
        
        private Collider StarshipCollider { get; set; }
        private Animator StarshipAnimator { get; set; }
        
        private void Start()
        {
            StarshipCollider = this.GetComponent<Collider>();
            StarshipAnimator = this.GetComponent<Animator>();
        }
        
        [Button("Test right")]
        public void TriggerBarrelRollRight() => StarshipAnimator.SetTrigger(BarrelRollRight);
        
        [Button("Test left")]
        public void TriggerBarrelRollLeft() => StarshipAnimator.SetTrigger(BarrelRollLeft);
        
        private void EnableCollider() => StarshipCollider.enabled = true;

        private void DisableCollider() => StarshipCollider.enabled = false;
    }
}