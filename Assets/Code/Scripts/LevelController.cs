using UnityEngine;

public class LevelController : MonoBehaviour
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
