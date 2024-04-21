using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speedMultiplier;
        private float _speed;
        private Vector3 _direction;
        
        private IInputService _inputService;

        [Inject]
        public void Constructor(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnMoveButton += SetSpeed;

            _direction = Vector3.right;
        }

        private void SetSpeed(float speed)
        {
            _speed = speed;
        }

        private void Update()
        {   
            transform.position += _direction * _speed * Time.deltaTime * _speedMultiplier;
        }
    }
}
