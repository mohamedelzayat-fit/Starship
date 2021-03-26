using Starship.Controllers.Core;
using UnityEngine;

namespace Starship.Controllers.Player
{
    public class StarshipController : MonoBehaviour
    {
        [SerializeField]
        private InputManagement InputManager;
        
        [SerializeField]
        [Range(0.1f, 100f)]
        private float Speed;

        private StarshipAnimationController StarshipAnimator { get; set; }
        
        private void Start()
        {
            InputManager.OnInputChanged += OnInputChanged;
            InputManager.OnEvade += OnEvade;
            StarshipAnimator = this.GetComponent<StarshipAnimationController>();
        }

        private void OnEvade(float horizontal)
        {
            if(horizontal > 0)
                StarshipAnimator.TriggerBarrelRollLeft();
            else
                StarshipAnimator.TriggerBarrelRollRight();

        }

        private void OnInputChanged(float horizontal, float vertical)
        {
            this.transform.position +=
                new Vector3(horizontal * Speed * Time.deltaTime, 0, vertical * Speed * Time.deltaTime);
        }
    }
}