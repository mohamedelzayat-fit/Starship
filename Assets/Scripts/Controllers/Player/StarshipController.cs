using Starship.Controllers.Core;
using Starship.ScriptableObjects;
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

        [SerializeField]
        private GameMetrics Metrics;

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

            this.transform.position = new Vector3(
                Mathf.Clamp(this.transform.position.x, Metrics.LimitLeft, Metrics.LimitRight),
                0,
                Mathf.Clamp(this.transform.position.z, Metrics.LimitDown, Metrics.LimitUp));
        }
    }
}