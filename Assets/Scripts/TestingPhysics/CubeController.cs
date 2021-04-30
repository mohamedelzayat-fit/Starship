using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starship.TestingPhysics
{
    public class CubeController : MonoBehaviour
    {
        private Rigidbody CurrentRigidBody;
        
        private void Start()
        {
            CurrentRigidBody = this.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                CurrentRigidBody.MovePosition(this.transform.position + (Vector3.forward * Time.deltaTime));
            }
        }
    }
}