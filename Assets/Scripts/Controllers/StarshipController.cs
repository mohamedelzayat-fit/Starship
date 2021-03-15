using UnityEngine;

namespace Starship.Controllers
{
    public class StarshipController : MonoBehaviour
    {
        [SerializeField]
        private InputManagement InputManager;
        
        [SerializeField]
        [Range(0.1f, 100f)]
        private float Speed;

        private void Start()
        {
            InputManager.OnInputChanged += OnInputChanged;
        }

        private void OnInputChanged(float horizontal, float vertical)
        {
            this.transform.position +=
                new Vector3(horizontal * Speed * Time.deltaTime, 0, vertical * Speed * Time.deltaTime);
        }
    }
}