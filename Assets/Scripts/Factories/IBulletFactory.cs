using UnityEngine;

namespace Factories
{
    public interface IBulletFactory
    {
        public GameObject CreateBullet(Vector3 initialPoint, Vector3 direction, int layer);
    }
}