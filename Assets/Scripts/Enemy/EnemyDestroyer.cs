using Bullet;
using Factories;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyDestroyer : MonoBehaviour
    {
        [SerializeField] private BulletCollider bulletCollider;
        
        private IEnemyFactory _enemyFactory;

        [Inject]
        public void Constructor(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }
        
        private void Awake()
        {
            bulletCollider.OnBulletHit += KillEnemy;
        }
        
        private void KillEnemy(Collider2D bullet)
        {
            Destroy(bullet.gameObject);
            Destroy(gameObject);
            _enemyFactory.RemoveEnemyFromDict(gameObject);
        }
    }
}
