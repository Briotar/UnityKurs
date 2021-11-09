using UnityEngine;
using Zenject;
using Core;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private CookieManager _spawnCookie;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private HUDManager _hudManager;

    public override void InstallBindings()
    {
        Container.Bind<PrefabFactory>().AsSingle();

        Container.Bind<CookieManager>().FromInstance(_spawnCookie).AsSingle();
        Container.Bind<SoundManager>().FromInstance(_soundManager).AsSingle();
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
        Container.Bind<HUDManager>().FromInstance(_hudManager).AsSingle();
    }
}