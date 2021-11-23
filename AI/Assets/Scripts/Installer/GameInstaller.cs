using Zenject;
using UnityEngine;
using Game;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private JsonController _jsonController;

    public override void InstallBindings()
    {
        Container.Bind<PrefabFactory>().AsSingle();

        Container.Bind<PlayerController>().FromInstance(_playerController).AsSingle();
        Container.Bind<JsonController>().FromInstance(_jsonController).AsSingle();
    }
}