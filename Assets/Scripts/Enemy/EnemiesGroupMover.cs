using Factories;
using UnityEngine;

namespace Enemy
{
    public class EnemiesGroupMover
    {
        private readonly IEnemyFactoryReadOnly _enemyFactoryReadOnly;

        public EnemiesGroupMover(IEnemyFactoryReadOnly enemyFactoryReadOnly)
        {
            _enemyFactoryReadOnly = enemyFactoryReadOnly;
            _enemyFactoryReadOnly.OnEnemySquadCreated += StartMove;
        }

        private void StartMove(LevelStaticData levelStaticData)
        {
            for (int i = 0; i < levelStaticData.rawCount; i++)
            {
                for (int j = 0; j < levelStaticData.columnCount; j++)
                {
                    _enemyFactoryReadOnly.EnemiesDictionary[new Vector2(i, j)]
                        .GetComponent<EnemyCoroutineMover>().StartMoveCoroutine(levelStaticData.rawCount - i);
                }
            }
        }
    }
}