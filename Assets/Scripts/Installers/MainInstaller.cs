using Factories;
using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterTickService();
            RegisterInputService();
            RegisterBulletFactory();
            RegisterEnviromentFactory();
            RegisterPlayerFactory();
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