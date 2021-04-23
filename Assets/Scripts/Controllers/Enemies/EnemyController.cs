using System;
using System.Collections;
using System.Collections.Generic;
using Starship.Core.Entities;
using UnityEngine;

namespace Starship.Controllers.Enemies
{
    public class EnemyController : TrackedEntity
    {
        [SerializeField]
        private Vector3 TravelingDirection;

        [SerializeField]
        private float Speed;
        
        private void OnEnable()
        {
            Invoke(nameof(DeactivateShip), 5f);
        }

        private void DeactivateShip()
        {
            this.gameObject.SetActive(false);
            this.transform.position = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Bullet"))
            {
                DeactivateShip();
            }
        }

        private void Update()
        {
            if (this.IsPaused) return;
            
            this.transform.position += TravelingDirection * Speed * Time.deltaTime;
        }
    }
}