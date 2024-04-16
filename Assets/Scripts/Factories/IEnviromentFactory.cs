using UnityEngine;

namespace Factories
{
    public interface IEnviromentFactory
    {
        public void CreateBackground(GameObject parent);
        public GameObject Background { get; }
    }
}