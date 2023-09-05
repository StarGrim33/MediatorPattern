using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private UnitConfig _playerConfig;
    [SerializeField] private Player _playerPrefab;

    public override void InstallBindings()
    {
        BindInstance();
    }

    private void BindInstance()
    {
        var player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab);
        Container.Bind<Player>().FromInstance(player).AsSingle();
        Container.Bind<PlayerHealth>().FromInstance(player.GetComponent<PlayerHealth>()).AsSingle();
    }
}