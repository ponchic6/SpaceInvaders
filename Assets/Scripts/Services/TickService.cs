using System;
using UnityEngine;

namespace Services
{
    public class TickService : MonoBehaviour, ITickService
    {
        public event Action OnTick;

        private void Update()
        {
            OnTick?.Invoke();
        }
    }
}