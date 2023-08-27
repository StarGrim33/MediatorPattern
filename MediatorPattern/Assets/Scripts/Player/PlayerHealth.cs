using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : UnitHealth, IDamageable
{
    public event UnityAction<float, float> OnHealthChanged;

    public event UnityAction PlayerDead;

    public float MaxHealth => _maxHealth;

    public float CurrentHealth
    {
        get
        {
            return _currenHealth;
        }
        private set
        {
            _currenHealth = Mathf.Clamp(value, 0, _maxHealth);

            if (_currenHealth <= 0)
                Die();
        }
    }

    private void Start()
    {
        Debug.Log($"Current health is {CurrentHealth}");
    }

    protected override void Die()
    {
        PlayerDead?.Invoke();
    }

    public void IncreaseMaxHealth(int amount)
    {
        _maxHealth += amount;
        _currenHealth = _maxHealth;
        OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
        Debug.Log($"Current health is {CurrentHealth}");
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentException("Value cannot be negative", nameof(damage));

        CurrentHealth -= damage;
        OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);
        Debug.Log($"Health is {CurrentHealth}");
    }
}
