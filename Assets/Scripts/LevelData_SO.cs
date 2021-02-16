using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelInfo
{
    [Tooltip("Scene Name")]
    public string levelId;
    public string levelName;
    public string sceneName;
    public Sprite levelSprite;
}

[CreateAssetMenu]
public class LevelData_SO : ScriptableObject
{
    public List<LevelInfo> AllLevelInfo = new List<LevelInfo>();

    public List<LevelInfo> GetAllLevelInfo() => AllLevelInfo;
    public LevelInfo GetLevelInfo(string _levelId)
    {
        for (int i = 0; i < AllLevelInfo.Count; i++)
        {
            if (AllLevelInfo[i].levelId == _levelId)
            {
                return AllLevelInfo[i];
            }
        }
        return AllLevelInfo[0];
    }
}