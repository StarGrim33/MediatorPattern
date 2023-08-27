using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _healthFillRectTransform;
    [SerializeField] private float _maxWidth;
    private PlayerLevelSystem _levelSystem;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth.OnHealthChanged += UpdateHealthBar;
        UpdateHealthBar(_playerHealth.CurrentHealth, _playerHealth.MaxHealth);
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthChanged -= UpdateHealthBar;
    }

    public void Init(PlayerLevelSystem playerLevelSystem, PlayerHealth playerHealth)
    {
        _levelSystem = playerLevelSystem;
        _playerHealth = playerHealth;
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
