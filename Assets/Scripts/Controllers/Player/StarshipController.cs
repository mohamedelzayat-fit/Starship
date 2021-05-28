using System;
using Starship.Controllers.Core;
using Starship.Core.Entities;
using Starship.ScriptableObjects;
using UnityEngine;

namespace Starship.Controllers.Player
{
    public class StarshipController : TrackedEntity
    {
        [SerializeField]
        private InputManagement InputManager;
        
        [SerializeField]
        private ShipAttribute ShipAttribute;

        [SerializeField]
        private GameMetrics Metrics;

        private StarshipAnimationController StarshipAnimator { get; set; }
        
        private void Start()
        {
            InputManager.OnInputChanged += OnInputChanged;
            InputManager.OnEvade += OnEvade;
            StarshipAnimator = this.GetComponent<StarshipAnimationController>();
            this.Health = 100;
        }
        
        private void OnEvade(float horizontal)
        {
            if (IsPaused) return;

            if(horizontal > 0)
                StarshipAnimator.TriggerBarrelRollLeft();
            else
                StarshipAnimator.TriggerBarrelRollRight();
        }

        private void OnInputChanged(float horizontal, float vertical)
        {
            if (IsPaused) return;
            
            this.transform.position +=
                new Vector3(horizontal * ShipAttribute.ShipSpeed * Time.deltaTime, 0, vertical * ShipAttribute.ShipSpeed * Time.deltaTime);

            this.transform.position = new Vector3(
                Mathf.Clamp(this.transform.position.x, Metrics.LimitLeft, Metrics.LimitRight),
                0,
                Mathf.Clamp(this.transform.position.z, Metrics.LimitDown, Metrics.LimitUp));
        }

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<TrackedEntity>().Health = 0;
            this.Health -= 50;
            
            Debug.Log("Registering collision " + other.name);
            if(Health <= 0)
                this.gameObject.SetActive(false);
        }
    }
}