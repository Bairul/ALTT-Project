using UnityEngine;

[RequireComponent(typeof(PlayerLevelController))]
public class ExperienceController : MonoBehaviour
{
    [Header("Experience Data")]
    [SerializeField] private int currentExperience = 0;
    [SerializeField] private int experienceToNextLevel;
    private PlayerLevelController levelController;

    [Header("Linear Scaling")]
    public int baseExperience = 10;
    public int experienceIncrement = 5;

    void Awake()
    {
        levelController = GetComponent<PlayerLevelController>();
    }

    void Start()
    {
        experienceToNextLevel = CalculateMaxExperienceLinear(levelController.currentLevel);
    }

    public void AddExperience(int experience)
    {
        if (levelController.IsMaxLevel()) {
            currentExperience = 0;
            return;
        }

        currentExperience += experience;
        if (currentExperience >= experienceToNextLevel)
        {
            levelController.LevelUp();
            currentExperience -= experienceToNextLevel;
            experienceToNextLevel = CalculateMaxExperienceLinear(levelController.currentLevel);
        }
    }

    int CalculateMaxExperienceLinear(int level)
    {
        return baseExperience + (level * experienceIncrement);
    }
}
