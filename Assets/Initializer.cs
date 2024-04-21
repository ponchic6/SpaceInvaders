using System;
using Factories;
using Services;
using UnityEngine;
using Zenject;

public class Initializer : MonoBehaviour
{
    private IEnviromentFactory _enviromentFactory;
    private IPlayerFactory _playerFactory;
    private ILevelSwitcher _levelSwitcher;

    [Inject]
    public void Constructor(IEnviromentFactory enviromentFactory, IPlayerFactory playerFactory,
        ILevelSwitcher levelSwitcher)
    {
        _levelSwitcher = levelSwitcher;
        _playerFactory = playerFactory;
        _enviromentFactory = enviromentFactory;
    }

    private void Awake()
    {
        _enviromentFactory.CreateBackground(gameObject);
        _playerFactory.CreatePlayer(gameObject);
        _levelSwitcher.NextLevelStart();
    }
}
