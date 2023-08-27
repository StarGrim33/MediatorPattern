using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LevelUpMediator _mediator;
    [SerializeField] private LevelView _levelView;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private HealthBar _healthBar;

    private void Awake()
    {
        PlayerLevelSystem levelSystem = new();
        _mediator.Init(levelSystem, _playerHealth);
        _levelView.Init(levelSystem);
        _healthBar.Init(levelSystem, _playerHealth);
    }
}
