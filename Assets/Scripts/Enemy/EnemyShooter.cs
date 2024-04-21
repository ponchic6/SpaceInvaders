using System.Collections;
using Bullet;
using Factories;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyShooter : MonoBehaviour
    {
        private IBulletFactory _bulletFactory;

        [Inject]
        public void Constructor(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        private void Start()
        {
            StartCoroutine(EnemyShootCoroutine());
        }

        private IEnumerator EnemyShootCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);
                
                RaycastHit2D raycastHit2D =
                    Physics2D.Raycast(transform.position + Vector3.down * 51f, Vector3.down, Mathf.Infinity);

                if (!raycastHit2D || !DidHitTheEnemy(raycastHit2D))
                {
                    _bulletFactory.CreateBullet(transform.position + Vector3.down * 51f, Vector3.down, 7);
                }
            }
        }

        private bool DidHitTheEnemy(RaycastHit2D raycastHit2D)
        {
            return raycastHit2D && raycastHit2D.transform.GetComponent<EnemyShooter>() != null;
        }
    }
}