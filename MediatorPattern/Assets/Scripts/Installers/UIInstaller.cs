using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Slider _experienceSlider;
    [SerializeField] private Transform _healthFillRectTransform;
    private float _maxHealthBarWidth = 10;

    public override void InstallBindings()
    {
        BindHealthBar();
        BindLevelView();
        BindLevelUpMediator();
    }

    private void BindHealthBar()
    {
        Container.Bind<Transform>().FromInstance(_healthFillRectTransform).AsSingle();
        Container.Bind<float>().FromInstance(_maxHealthBarWidth);
    }

    private void BindLevelView()
    {
        Container.Bind<TMP_Text>().WithId(Constants.LevelText).FromInstance(_levelText).AsSingle();
        Container.Bind<Slider>().FromInstance(_experienceSlider).AsSingle();
    }

    private void BindLevelUpMediator()
    {
        Container.Bind<Button>().FromInstance(_button).AsSingle();
    }
}