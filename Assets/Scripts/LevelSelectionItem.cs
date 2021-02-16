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
    [SerializeField] Image imgItem;
    [SerializeField] Button btnItem;

    [HideInInspector] public LevelInfo levelInfo;
    public void AssignValue(LevelInfo _levelInfo)
    {
        levelInfo = _levelInfo;
        imgItem.sprite = _levelInfo.levelSprite;
    }
}
