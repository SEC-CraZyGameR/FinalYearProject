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

    public void AssignValue(LevelInfo _levelInfo)
    {
        imgItem.sprite = _levelInfo.levelSprite;
    }
}
