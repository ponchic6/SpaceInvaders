using System;
using UnityEngine;

namespace Services
{
    public class InputService : IInputService
    {
        public event Action<float> OnMoveButton;
        public event Action OnShoot;

        private readonly ITickService _tickService;

        public InputService(ITickService tickService)
        {
            _tickService = tickService;
            _tickService.OnTick += CheckMoveButton;
            _tickService.OnTick += CheckShoot;
        }

        private void CheckShoot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {   
                OnShoot?.Invoke();
            }
        }

        private void CheckMoveButton()
        {
            float horizontal = Input.GetAxis("Horizontal");
            
            OnMoveButton?.Invoke(horizontal);
        }
    }
}