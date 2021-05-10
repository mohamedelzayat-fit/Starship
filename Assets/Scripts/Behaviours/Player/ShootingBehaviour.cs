using Starship.Controllers.Core;
using Starship.Core;
using Starship.ScriptableObjects;
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
        private ShipAttribute ShipAttribute;
        
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
                NextFire = ShipAttribute.FireRate + Time.time;
                BulletPool.InstantiateObject(GunPoint.position);
            }
        }
    }
}
