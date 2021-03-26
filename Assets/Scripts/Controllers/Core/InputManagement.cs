using System;
using UnityEngine;

namespace Starship.Controllers.Core
{
    public class InputManagement : MonoBehaviour
    {
        //TODO: Change this to be keyboard and joystick friendly 
        [SerializeField]
        private KeyCode ShootingKey;
        
        [SerializeField]
        private KeyCode EvadeKey;
        
        public Action<float, float> OnInputChanged;
        public Action<float> OnEvade;
        public Action OnShoot;

        private void Update()
        {
            OnInputChanged?.Invoke(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if(Input.GetKey(ShootingKey))
                OnShoot?.Invoke();
            
            if(Input.GetKeyDown(EvadeKey))
                OnEvade?.Invoke(Input.GetAxisRaw("Horizontal"));
        }
    }
}
