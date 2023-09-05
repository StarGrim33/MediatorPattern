using TMPro;
using UnityEngine;
using Zenject;

public class HealthTextView : MonoBehaviour
{
    private TMP_Text _healthValueText;
    private PlayerHealth _health;

    [Inject] 
    public void Construct(TMP_Text text, PlayerHealth damageable)
    {
        _healthValueText = text;
        _health = damageable;
    }

    private void Start()
    {
        _health.OnHealthChanged += UpdateHealthBar;
        UpdateHealthBar(_health.CurrentHealth, _health.MaxHealth);
    }

    private void OnDestroy()
    {
        _health.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        _healthValueText.text = currentHealth.ToString();
    }
}
