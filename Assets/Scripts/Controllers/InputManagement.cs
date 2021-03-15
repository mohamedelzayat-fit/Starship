using System;
using UnityEngine;

namespace Starship.Controllers
{
    public class InputManagement : MonoBehaviour
    {
        public Action<float, float> OnInputChanged;

        private void Update()
        {
            OnInputChanged?.Invoke(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}
