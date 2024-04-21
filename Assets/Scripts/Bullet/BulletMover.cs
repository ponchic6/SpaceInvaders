using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    
    public Vector3 Direction { get; set; }

    private void Update()
    {
        transform.position += Direction * _bulletSpeed * Time.deltaTime;
    }
}
