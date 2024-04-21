using Factories;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        private IBulletFactory _bulletFactory;
        private IInputService _inputService;
        private IEnviromentFactory _enviromentFactory;

        [Inject]
        public void Constructor(IBulletFactory bulletFactory, IInputService inputService,
            IEnviromentFactory enviromentFactory)
        {
            _enviromentFactory = enviromentFactory;
            
            _inputService = inputService;
            _inputService.OnShoot += Shoot;
            
            _bulletFactory = bulletFactory;
        }

        private void Shoot()
        {
            _bulletFactory
                .CreateBullet(transform.position + Vector3.up * GetComponent<BoxCollider2D>().size.y / 2, Vector3.up, 0);
        }
    }
}