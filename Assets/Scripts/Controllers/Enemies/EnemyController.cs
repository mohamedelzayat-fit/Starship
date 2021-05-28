using System;
using System.Collections;
using System.Collections.Generic;
using Starship.Core;
using Starship.Core.Entities;
using Starship.ScriptableObjects;
using UnityEngine;

namespace Starship.Controllers.Enemies
{
    public class EnemyController : TrackedEntity
    {
        [SerializeField] 
        private DirectedShipAttribute ShipAttribute;

        private void OnEnable()
        {
            Invoke(nameof(DeactivateShip), 5f);
        }

        private void DeactivateShip()
        {
            // this.gameObject.SetActive(false);
            // this.transform.position = Vector3.zero;
            // this.Health = 100;
            
            Destroy(this.gameObject);
        }

        private void Update()
        {
            if (this.IsPaused) return;
            
            this.transform.position += ShipAttribute.TravelingDirection * ShipAttribute.ShipSpeed * Time.deltaTime;

            if (this.Health <= 0)
                DeactivateShip();
        }
    }
}