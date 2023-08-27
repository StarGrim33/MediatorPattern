using UnityEngine;
using UnityEngine.UI;

public class LevelUpMediator : MonoBehaviour
{
    [SerializeField] private Button _button;

    private PlayerLevelSystem _playerLevelSystem;
    private PlayerHealth _playerHealth;
    private int _experiencePerClick = 25;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnLevelUpButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnLevelUpButtonClick);
        _playerLevelSystem.OnLevelChanged -= OnLevelChanged;
    }

    public void Init(PlayerLevelSystem playerLevelSystem, PlayerHealth playerHealth)
    {
        _playerLevelSystem = playerLevelSystem;
        _playerHealth = playerHealth;
        _playerLevelSystem.OnLevelChanged += OnLevelChanged;
    }

    private void OnLevelChanged(int value)
    {
        _playerHealth.IncreaseMaxHealth(_playerLevelSystem.IncreaseHealthPerLevel);
    }

    private void OnLevelUpButtonClick()
    {
        _playerLevelSystem.AddExperience(_experiencePerClick);
    }
}
