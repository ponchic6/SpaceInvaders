using System;
using Factories;
using UnityEngine;
using Zenject;

public class Initializer : MonoBehaviour
{
    private IEnviromentFactory _enviromentFactory;
    private IPlayerFactory _playerFactory;

    [Inject]
    public void Constructor(IEnviromentFactory enviromentFactory, IPlayerFactory playerFactory)
    {
        _playerFactory = playerFactory;
        _enviromentFactory = enviromentFactory;
    }

    private void Awake()
    {
        _enviromentFactory.CreateBackground(gameObject);
        _playerFactory.CreatePlayer(gameObject);        
    }
}