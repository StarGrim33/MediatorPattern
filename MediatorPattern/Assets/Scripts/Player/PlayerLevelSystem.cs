using System.Linq;
using UnityEngine.Events;

public class PlayerLevelSystem
{
    private int _level;
    private int _experience;
    private readonly int[] _experienceLevel;

    public event UnityAction OnExperienceChanged;

    public event UnityAction<int> OnLevelChanged;

    public int Level => _level;

    public float ExperienceNormalized => (float)_experience / ExperienceToNextLevel;

    public int ExperienceToNextLevel => _experienceLevel[_level];

    public bool IsMaxLevel => _level == _experienceLevel.Length - 1;

    public int IncreaseHealthPerLevel => 10;

    public PlayerLevelSystem()
    {
        _level = 1;
        _experience = 0;
        _experienceLevel = Enumerable.Range(100, 341).ToArray();
    }

    public void AddExperience(int amount)
    {
        if (IsMaxLevel == false)
        {
            _experience += amount;

            while (_experience >= ExperienceToNextLevel)
            {
                _experience -= ExperienceToNextLevel;
                _level++;
                UnityEngine.Debug.Log($"Current level is {Level}");
                OnLevelChanged?.Invoke(_level);
            }

            OnExperienceChanged?.Invoke();
        }
    }
}
