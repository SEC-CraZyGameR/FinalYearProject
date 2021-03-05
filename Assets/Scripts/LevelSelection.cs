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

    [Header("------Buttons------")]
    [SerializeField] Button btnLeft;
    [SerializeField] Button btnRight;

    [Space(20)]

    [Header("LevelData Scriptable Object")]
    [SerializeField] LevelData_SO levelData_SO;

    public List<GameObject> levelSelectionItems = new List<GameObject>();


    int currentPage = 1;
    int startIndex = 0;
    int maxPage = 0;

    public void OnEnable()
    {
        currentPage = 0;
        startIndex = 0;
        maxPage = (levelData_SO.AllLevelInfo.Count / 3);
        ShowLevelItem();
    }

    public void LeftBtnCallBack()
    {
        // Check Lower Bound
        if (currentPage > 0)
        {
            currentPage--;
            startIndex = currentPage * 3;
            ShowLevelItem(startIndex);
        }

        //Debug.Log("Left btn Response");
    }

    public void RightBtnCallBack()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            startIndex = currentPage * 3;
            ShowLevelItem(startIndex);
        }

        //Debug.Log("Right btn Response");
    }

    void ShowLevelItem(int _startIndex = 0)
    {
        int itemIndex = 0;
        for (int i = _startIndex; i < _startIndex + 3; i++)
        {
            ILevelSelection item = levelSelectionItems[itemIndex].GetComponent<ILevelSelection>();
            if (i > levelData_SO.AllLevelInfo.Count - 1)
            {
                levelSelectionItems[itemIndex].SetActive(false);
            }
            else
            {
                levelSelectionItems[itemIndex].SetActive(true);
                item.AssignValue(levelData_SO.AllLevelInfo[i]);
            }

            itemIndex++;
        }

        CheckLeftRightBtn();
    }

    private void CheckLeftRightBtn()
    {
        if (currentPage < 1)
        {
            btnLeft.gameObject.SetActive(false);
        }
        else
        {
            btnLeft.gameObject.SetActive(true);
        }

        if (currentPage >= maxPage)
        {
            btnRight.gameObject.SetActive(false);
        }
        else
        {
            btnRight.gameObject.SetActive(true);
        }
    }
}
