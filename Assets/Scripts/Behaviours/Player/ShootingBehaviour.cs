using Starship.Controllers.Core;
using Starship.Core;
using UnityEngine;

namespace Starship.Behaviours.Player
{
    public class ShootingBehaviour : MonoBehaviour
    {
        [SerializeField]
        private InputManagement InputManager;

        [SerializeField]
        private Transform GunPoint;

        [SerializeField]
        private float FireRate;
        
        private ObjectPool BulletPool { get; set; }
        private float NextFire { get; set; }
        
        private void Start()
        {
            InputManager.OnShoot += OnShoot;
            BulletPool = this.GetComponent<ObjectPool>();
        }

        private void OnShoot()
        {
            if (Time.time > NextFire)
            {
                NextFire = FireRate + Time.time;
                BulletPool.InstantiateObject(GunPoint.position);
            }
        }
    }
}
