using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Factories
{
    public class EnemyFactory : IEnemyFactory, IEnemyFactoryReadOnly
    {
        public event Action OnAllEnemiesKilled;
        public event Action<LevelStaticData> OnEnemySquadCreated;

        private const string EnemyPath = "Prefabs/Characters/Enemy";

        private readonly DiContainer _diContainer;

        private Dictionary<Vector2, GameObject> _enemiesDictionary = new Dictionary<Vector2, GameObject>();

        public Dictionary<Vector2, GameObject> EnemiesDictionary => _enemiesDictionary;

        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void CreateEnemiesSquad(Transform parent, LevelStaticData staticDataLevel)
        {
            for (int i = 0; i < staticDataLevel.rawCount; i++)
            {
                for (int j = 0; j < staticDataLevel.columnCount; j++)
                {
                    Vector3 enemyPos = new Vector3( 400 - j * 300, 400 - 150 * i, 0);
                    GameObject enemy = _diContainer.InstantiatePrefabResource(EnemyPath, parent);
                    enemy.transform.localPosition = enemyPos;
                    _enemiesDictionary.Add(new Vector2(i, j), enemy);
                }
            }
            
            OnEnemySquadCreated?.Invoke(staticDataLevel);
        }

        public void KillAllEnemies()
        {
            foreach (KeyValuePair<Vector2, GameObject> kvp in _enemiesDictionary)
            {
                Object.Destroy(kvp.Value);
            }
            
            _enemiesDictionary.Clear();
        }

        public void RemoveEnemyFromDict(GameObject enemy)
        {
            KeyValuePair<Vector2, GameObject> enemyShouldBeRemoved =
                _enemiesDictionary.First(kvp => kvp.Value == enemy);

            _enemiesDictionary.Remove(enemyShouldBeRemoved.Key);
            
            if (_enemiesDictionary.Count == 0)
                OnAllEnemiesKilled?.Invoke();
        }
    }
}