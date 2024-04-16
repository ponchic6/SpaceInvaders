using UnityEngine;

namespace Factories
{
    public interface IPlayerFactory
    {
        public void CreatePlayer(GameObject gameObject);
    }
}