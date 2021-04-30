using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Starship.TestingPhysics
{
    public class DetectorBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name + " has entered the trigger area");
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("<color=red> "+ other.gameObject.name + " has exited the trigger area </color>");
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log("<color=blue> "+ other.gameObject.name + " has stayed inside the trigger area </color>");
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.name + " has started the hit area");
        }

        private void OnCollisionExit(Collision other)
        {
            Debug.Log("<color=red> "+ other.gameObject.name + " has stopped colliding </color>");
        }

        private void OnCollisionStay(Collision other)
        {
            Debug.Log("<color=green> "+ other.gameObject.name + " is constantly in touch/collision </color>");
        }
    }
}