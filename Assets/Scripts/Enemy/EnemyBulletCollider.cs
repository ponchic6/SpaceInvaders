using System;
using UnityEngine;

public class EnemyBulletCollider : MonoBehaviour
{
    public event Action OnBulletHit;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BulletMover>() != null)
        {
            OnBulletHit?.Invoke();
        }
    }
}
