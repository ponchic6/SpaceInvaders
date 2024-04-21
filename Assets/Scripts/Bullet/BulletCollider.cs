using System;
using Enemy;
using UnityEngine;

namespace Bullet
{
    public class BulletCollider : MonoBehaviour
    {
        public event Action<Collider2D> OnBulletHit;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<BulletMover>() != null)
            {
                OnBulletHit?.Invoke(other);
            }

            if (other.GetComponent<EnemyShooter>() != null)
            {
                OnBulletHit?.Invoke(other);
            }
        }
    }
}