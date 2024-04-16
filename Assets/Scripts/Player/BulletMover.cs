using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    
    private Vector3 _direction = Vector3.up;

    private void Update()
    {
        transform.position += _direction * _bulletSpeed * Time.deltaTime;
    }
}
