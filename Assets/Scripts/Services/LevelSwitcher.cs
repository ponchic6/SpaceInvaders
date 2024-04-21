using Factories;

namespace Services
{
    public class LevelSwitcher : ILevelSwitcher
    {
        private int _currentLevelIndex;
        
        private readonly IEnemyFactory _enemyFactory;
        private readonly IEnviromentFactory _enviromentFactory;
        private readonly StaticData _staticData;

        public LevelSwitcher(IEnemyFactory enemyFactory, StaticData staticData, IEnviromentFactory enviromentFactory)
        {
            _staticData = staticData;
            _enviromentFactory = enviromentFactory;

            _enemyFactory = enemyFactory;
            _enemyFactory.OnAllEnemiesKilled += NextLevelStart;
        }

        public void NextLevelStart()
        {
            if (_currentLevelIndex >= _staticData.levels.Count) _currentLevelIndex = 0;

            LevelStaticData levelStaticData = _staticData.levels[_currentLevelIndex];
            _enemyFactory.CreateEnemiesSquad(_enviromentFactory.Background.transform, levelStaticData);
            _currentLevelIndex++;
        }

        public void RestartLevels()
        {
            LevelStaticData levelStaticData = _staticData.levels[0];

            _enemyFactory.KillAllEnemies();            
            _enemyFactory.CreateEnemiesSquad(_enviromentFactory.Background.transform, levelStaticData);

            _currentLevelIndex = 1;
        }
    }
}