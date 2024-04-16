using System;

namespace Services
{
    public interface ITickService
    {
        public event Action OnTick;
    }
}