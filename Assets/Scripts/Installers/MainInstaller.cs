using Enemy;
using Factories;
using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private StaticData _staticData;
        
        public override void InstallBindings()
        {
            RegisterTickService();
            RegisterStaticData();
            RegisterInputService();
            RegisterEnviromentFactory();
            RegisterBulletFactory();
            RegisterEnemyFactory();
            RegisterLevelSwitcher();
            RegisterPlayerFactory();
            RegisterEnemiesGroupMover();
        }

        private void RegisterEnemiesGroupMover()
        {
            EnemiesGroupMover enemiesGroupMover = Container.Instantiate<EnemiesGroupMover>();
        }

        private void RegisterLevelSwitcher()
        {
            ILevelSwitcher levelSwitcher = Container.Instantiate<LevelSwitcher>();
            Container.Bind<ILevelSwitcher>().FromInstance(levelSwitcher).AsSingle();
        }

        private void RegisterStaticData()
        {
            Container.Bind<StaticData>().FromInstance(_staticData).AsSingle();
        }

        private void RegisterEnemyFactory()
        {
            EnemyFactory enemyFactory = Container.Instantiate<EnemyFactory>();
            Container.Bind<IEnemyFactory>().FromInstance(enemyFactory).AsSingle();
            Container.Bind<IEnemyFactoryReadOnly>().FromInstance(enemyFactory).AsSingle();
        }

        private void RegisterPlayerFactory()
        {
            IPlayerFactory playerFactory = Container.Instantiate<PlayerFactory>();
            Container.Bind<IPlayerFactory>().FromInstance(playerFactory).AsSingle();
        }

        private void RegisterEnviromentFactory()
        {
            IEnviromentFactory enviromentFactory = Container.Instantiate<EnviromentFactory>();
            Container.Bind<IEnviromentFactory>().FromInstance(enviromentFactory).AsSingle();
        }

        private void RegisterBulletFactory()
        {
            IBulletFactory bulletFactory = Container.Instantiate<BulletFactory>();
            Container.Bind<IBulletFactory>().FromInstance(bulletFactory).AsSingle();
        }

        private void RegisterInputService()
        {
            IInputService inputService = Container.Instantiate<InputService>();
            Container.Bind<IInputService>().FromInstance(inputService).AsSingle();
        }

        private void RegisterTickService()
        {
            GameObject tickService = new GameObject();
            tickService.AddComponent<TickService>();
            tickService.name = "TickService";
            DontDestroyOnLoad(tickService);
            Container.Bind<ITickService>().FromInstance(tickService.GetComponent<TickService>()).AsSingle();
        }
    }
}