using UnityEngine;
using Zenject;

namespace Factories
{
    public class EnviromentFactory : IEnviromentFactory
    {
        private const string BackgroundPath = "Prefabs/UIPrefabs/Background";

        private readonly DiContainer _diContainer;
        private GameObject _background;

        public GameObject Background => _background;

        public EnviromentFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void CreateBackground(GameObject parent)
        {
            _background = _diContainer.InstantiatePrefabResource(BackgroundPath, parent.transform);
        }
    }
}