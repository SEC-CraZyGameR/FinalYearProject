using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelSelection
{
    void AssignValue(LevelInfo _levelInfo);
}

public class LevelSelectionItem : MonoBehaviour, ILevelSelection
{
    public void AssignValue(LevelInfo _levelInfo)
    {
        throw new System.NotImplementedException();
    }
}
