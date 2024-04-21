using UnityEngine;

namespace Bullet
{
    public class BulletDestroyer : MonoBehaviour
    {
        private void Update()
        {
            if (BulletInScreenBoundary())
            {
                Destroy(gameObject);
            }
        }

        private bool BulletInScreenBoundary()
        {
            return transform.localPosition.x > Screen.width / 2 ||
                   transform.localPosition.x < -Screen.width / 2 ||
                   transform.localPosition.y < -Screen.height / 2 ||
                   transform.localPosition.y > Screen.height / 2;
        }
    }
}
