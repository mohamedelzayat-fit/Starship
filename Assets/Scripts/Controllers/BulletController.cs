using System;
using System.Collections;
using System.Collections.Generic;
using Starship.Core.Entities;
using Starship.ScriptableObjects;
using UnityEngine;

namespace Starship
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] 
        private Projectile ProjectileAttribute;
        
        private void OnEnable()
        {
            Invoke(nameof(DeactivateBullet), 0.5f);
        }

        private void DeactivateBullet()
        {
            this.gameObject.SetActive(false);
            this.transform.position = Vector3.zero;
        }

        private void Update()
        {
            this.transform.position += new Vector3(0, 0, 10) * ProjectileAttribute.TravelingSpeed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            ProjectileAttribute.ApplyEffect(other.GetComponent<TrackedEntity>());
        }
    }
}
