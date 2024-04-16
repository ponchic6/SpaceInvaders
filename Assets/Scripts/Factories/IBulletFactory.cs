using UnityEngine;

namespace Factories
{
    public interface IBulletFactory
    {
        public GameObject CreateBullet(GameObject parent);
    }
}