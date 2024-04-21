using System;
using System.Collections.Generic;
using UnityEngine;

namespace Factories
{
    public interface IEnemyFactory
    {
        public event Action OnAllEnemiesKilled;
        public event Action<LevelStaticData> OnEnemySquadCreated;
        public void CreateEnemiesSquad(Transform parent, LevelStaticData staticDataLevel);
        public void RemoveEnemyFromDict(GameObject enemy);
        public Dictionary<Vector2, GameObject> EnemiesDictionary { get; }
        public void KillAllEnemies();
    }
}