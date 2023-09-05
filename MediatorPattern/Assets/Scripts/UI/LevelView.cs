using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelView : MonoBehaviour
{
    private TMP_Text _levelText;
    private Slider _experienceSlider;
    private PlayerLevelSystem _levelSystem;

    private void OnDisable()
    {
        _levelSystem.OnExperienceChanged -= OnExperienceChanged;
        _levelSystem.OnLevelChanged -= OnLevelChanged;
    }

    [Inject]
    public void Construct(PlayerLevelSystem playerLevelSystem, [Inject(Id = "LevelText")] TMP_Text text, Slider slider)
    {
        _levelText = text;
        _levelSystem = playerLevelSystem;
        _experienceSlider = slider;
        _levelSystem.OnExperienceChanged += OnExperienceChanged;
        _levelSystem.OnLevelChanged += OnLevelChanged;
        SetStartValue();
    }

    private void OnLevelChanged(int value)
    {
        _levelText.text = value.ToString();
    }

    private void OnExperienceChanged()
    {
        float progress = _levelSystem.ExperienceNormalized;
        _experienceSlider.value = progress;
    }

    private void SetStartValue()
    {
        _levelText.text = _levelSystem.Level.ToString();
    }
}
