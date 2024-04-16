using Factories;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Shooter : MonoBehaviour
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
            GameObject bullet = _bulletFactory.CreateBullet(_enviromentFactory.Background);
            bullet.transform.position = transform.position;
        }
    }
}