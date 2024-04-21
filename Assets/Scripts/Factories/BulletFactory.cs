using Player;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class BulletFactory : IBulletFactory
    {
        private const string BulletPath = "Prefabs/UIPrefabs/Bullet";
        
        private readonly DiContainer _diContainer;
        private readonly IEnviromentFactory _enviromentFactory;

        public BulletFactory(DiContainer diContainer, IEnviromentFactory enviromentFactory)
        {
            _diContainer = diContainer;
            _enviromentFactory = enviromentFactory;
        }
        
        public GameObject CreateBullet(Vector3 initialPoint, Vector3 direction, int layer)
        {
            GameObject bullet = _diContainer.InstantiatePrefabResource(BulletPath, _enviromentFactory.Background.transform);
            bullet.transform.position = initialPoint;
            bullet.GetComponent<BulletMover>().Direction = direction;
            bullet.layer = layer;
            return bullet;
        }
    }
}