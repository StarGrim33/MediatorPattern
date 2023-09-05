using UnityEngine;
using Zenject;

public class HealthBar : MonoBehaviour
{
    private Transform _healthFillRectTransform;
    private PlayerLevelSystem _levelSystem;
    private PlayerHealth _playerHealth;
    private float _maxWidth;

    private void Start()
    {
        _playerHealth.OnHealthChanged += UpdateHealthBar;
        UpdateHealthBar(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthChanged -= UpdateHealthBar;
    }

    [Inject]
    public void Construct(PlayerLevelSystem playerLevelSystem, PlayerHealth playerHealth, Transform healthFillRectTransform, float maxWidth)
    {
        _levelSystem = playerLevelSystem;
        _playerHealth = playerHealth;
        _maxWidth = maxWidth;
        _healthFillRectTransform = healthFillRectTransform;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        SetHealthFillWidth(1f + _levelSystem.Level * .1f);
    }

    private void SetHealthFillWidth(float healthBarSize)
    {
        _healthFillRectTransform.localScale = new Vector3(.7f *  healthBarSize, 1, 1);
    }
}
