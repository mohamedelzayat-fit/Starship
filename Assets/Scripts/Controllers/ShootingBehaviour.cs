using UnityEngine;

namespace Starship.Controllers
{
    public class ShootingBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameObject Bullet;

        [SerializeField] 
        private Transform BulletsParent;

        [SerializeField]
        private InputManagement InputManager;
        
        private void Start()
        {
            InputManager.OnShoot += OnShoot;
        }

        private void OnShoot()
        {
            Instantiate(Bullet,
                new Vector3(Random.Range(-10, 10),
                    Random.Range(-10, 10),
                    Random.Range(-10, 10)), Quaternion.identity, BulletsParent);
        }
    }
}
