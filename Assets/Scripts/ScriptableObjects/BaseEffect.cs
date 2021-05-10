using System.Collections;
using System.Collections.Generic;
using Starship.Core.Entities;
using Starship.Managers;
using UnityEngine;

namespace Starship.ScriptableObjects
{
    public abstract class BaseEffect : ScriptableObject
    {
        public string Name;
        public GameObject Prefab;
        public abstract void ApplyEffect(TrackedEntity trackedEntity);
    }
}