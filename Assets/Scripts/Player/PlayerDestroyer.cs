using Bullet;
using Services;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerDestroyer : MonoBehaviour
    {
        [SerializeField] private BulletCollider _bulletCollider;
        
        private ILevelSwitcher _levelSwitcher;

        [Inject]
        public void Constructor(ILevelSwitcher levelSwitcher)
        {
            _levelSwitcher = levelSwitcher;
        }
        
        private void Awake()
        {
            _bulletCollider.OnBulletHit += OnBulletHit;
        }

        private void OnBulletHit(Collider2D collider2D)
        {
            _levelSwitcher.RestartLevels();
        }
    }
}
