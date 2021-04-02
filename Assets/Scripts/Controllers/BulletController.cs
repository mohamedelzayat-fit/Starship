using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starship
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField]
        private float BulletSpeed;
        
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
            this.transform.position += new Vector3(0, 0, 10) * BulletSpeed * Time.deltaTime;
        }
    }
}
