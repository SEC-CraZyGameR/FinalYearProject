using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appdelegate
{
    public static Appdelegate SharedInstance = null;
    #region Singleton
    public static Appdelegate SharedManager()
    {
        return SharedInstance ?? (SharedInstance = Appdelegate.Create());
    }

    private static Appdelegate Create()
    {
        Appdelegate ret = new Appdelegate();
        if (ret != null && ret.Init())
        {
            return ret;
        }
        return null;
    }

    private bool Init()
    {
        return true;
    }
    #endregion

    public LevelInfo selectedLevelIfo { get; set; }

    public readonly static int levelScore = 100;
    public int currtentLevelScore = levelScore;

    #region Level Management
    public static int GetCurrentLevel() => PlayerPrefs.GetInt(Constants.currentLevel, 1);
    public void UpdateCurrentLevel() => SetLevel(GetCurrentLevel() + 1);
    public static void SetLevel(int level) => PlayerPrefs.SetInt(Constants.currentLevel, level);
    #endregion
}
