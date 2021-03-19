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

        private void Start()
        {
            Destroy(this.gameObject, 2);
        }

        private void Update()
        {
            this.transform.position += new Vector3(0, 0, 10) * BulletSpeed * Time.deltaTime;
        }
    }
}
