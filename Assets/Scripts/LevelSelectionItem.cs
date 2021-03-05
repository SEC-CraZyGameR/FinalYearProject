using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ILevelSelection
{
    void AssignValue(LevelInfo _levelInfo);
}

public class LevelSelectionItem : MonoBehaviour, ILevelSelection
{
    [SerializeField] Button btnItem;

    [Header("------Images------")]
    [SerializeField] Image imgItem;
    [SerializeField] Image imgLoack;

    [HideInInspector] public LevelInfo levelInfo;
    public void AssignValue(LevelInfo _levelInfo)
    {
        levelInfo = _levelInfo;
        imgItem.sprite = _levelInfo.levelSprite;
        ManagerLock(!_levelInfo.isUnlocked);
    }

    private void ManagerLock(bool condition)
    {
        imgLoack.gameObject.SetActive(condition);
    }
}
