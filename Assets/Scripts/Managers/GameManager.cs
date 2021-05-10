using System.Collections.Generic;
using Starship.Controllers.Core;
using Starship.Core.Entities;
using UnityEngine;

namespace Starship.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<TrackedEntity> TrackedEntities;

        [SerializeField]
        private InputManagement InputManager;

        private void Start()
        {
            InputManager.OnPause += OnPause;
        }

        private void OnPause()
        {
            for (var i = 0; i < TrackedEntities.Count; i++)
                TrackedEntities[i].IsPaused = !TrackedEntities[i].IsPaused;
        }

        public void AddTrackedEntity(TrackedEntity trackedEntity)
        {
            this.TrackedEntities.Add(trackedEntity);
        }
        
        public void AddToTrackedEntities(List<TrackedEntity> trackedEntity)
        {
            for (int i = 0; i < trackedEntity.Count; i++)
            {
                this.TrackedEntities.Add(trackedEntity[i]);
            }
        }
    }
}