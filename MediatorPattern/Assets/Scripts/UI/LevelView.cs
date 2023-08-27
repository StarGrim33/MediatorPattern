using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Slider _experienceSlider;
    private PlayerLevelSystem _levelSystem;

    private void OnDisable()
    {
        _levelSystem.OnExperienceChanged -= OnExperienceChanged;
        _levelSystem.OnLevelChanged -= OnLevelChanged;
    }

    public void Init(PlayerLevelSystem playerLevelSystem)
    {
        _levelSystem = playerLevelSystem;
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
