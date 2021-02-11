using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    #region Singleton
    static LevelSelection _instance;
    public static LevelSelection Instance
    {
        get
        {
            if (_instance)
                return _instance;

            return null;
        }
    }
    void Awake()
    {
        _instance = this;
    }

    #endregion

    [Header("Buttons")]
    [SerializeField] Button btnLeft;
    [SerializeField] Button btnRight;

    [Header("LevelData Scriptable Object")]
    [SerializeField] LevelData_SO levelData_SO;

    public List<GameObject> levelSelectionItems = new List<GameObject>();



    void LeftBtnCallBack()
    {

    }

    void RightBtnCallBack()
    {

    }

    void ShowLevelItem(int _startIndex = 0)
    {
        int itemIndex = 0;
        for (int i = _startIndex; i < _startIndex + 3; i++)
        {
            ILevelSelection item = levelSelectionItems[itemIndex++].GetComponent<ILevelSelection>();
            item.AssignValue(levelData_SO.AllLevelInfo[i]);
        }
    }
}
