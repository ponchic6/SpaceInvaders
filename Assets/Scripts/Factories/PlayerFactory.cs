using UnityEngine;
using Zenject;

namespace Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private const string PlayerPath = "Prefabs/Characters/Player";
        
        private readonly DiContainer _diContainer;

        public PlayerFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void CreatePlayer(GameObject parent)
        {
            _diContainer.InstantiatePrefabResource(PlayerPath, parent.transform);
        }
    }
}