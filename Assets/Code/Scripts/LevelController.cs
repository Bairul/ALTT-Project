using UnityEngine;

public class PlayerLevelController : MonoBehaviour
{
    public int currentLevel = 0;
    public int maxLevel = 10;

    public void LevelUp()
    {
        currentLevel++;
    }

    public bool IsMaxLevel()
    {
        return currentLevel == maxLevel;
    }
}
