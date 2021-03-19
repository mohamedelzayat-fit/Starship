using System;
using UnityEngine;

namespace Starship.Controllers
{
    public class InputManagement : MonoBehaviour
    {
        //TODO: Change this to be keyboard and joystick friendly 
        [SerializeField]
        private KeyCode ShootingKey;
        
        public Action<float, float> OnInputChanged;
        public Action OnShoot;

        private void Update()
        {
            OnInputChanged?.Invoke(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            
            if(Input.GetKey(ShootingKey))
                OnShoot?.Invoke();
        }
    }
}
