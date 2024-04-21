using System;
using System.Collections.Generic;
using UnityEngine;

namespace Factories
{
    public interface IEnemyFactoryReadOnly
    {
        public event Action OnAllEnemiesKilled;
        public event Action<LevelStaticData> OnEnemySquadCreated;
        public Dictionary<Vector2, GameObject> EnemiesDictionary { get; }
    }
}