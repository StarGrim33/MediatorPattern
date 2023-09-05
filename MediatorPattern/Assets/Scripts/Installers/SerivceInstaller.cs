using TMPro;
using UnityEngine;
using Zenject;

public class SerivceInstaller : MonoInstaller
{
    [SerializeField] private TMP_Text _text;

    public override void InstallBindings()
    {
        Container.Bind<LevelUpMediator>().AsSingle();
        Container.Bind<PlayerLevelSystem>().AsSingle();
        Container.Bind<TMP_Text>().FromInstance(_text);
    }
}