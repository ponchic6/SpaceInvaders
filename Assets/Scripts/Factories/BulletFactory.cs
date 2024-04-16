using Player;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class BulletFactory : IBulletFactory
    {
        private const string BulletPath = "Prefabs/UIPrefabs/Bullet";
        
        private readonly DiContainer _diContainer;

        public BulletFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public GameObject CreateBullet(GameObject parent)
        {
            return _diContainer.InstantiatePrefabResource(BulletPath, parent.transform);
        }
    }
}