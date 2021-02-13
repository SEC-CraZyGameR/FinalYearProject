using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appdelegate
{
    public static Appdelegate sharedInstance = null;

    public static Appdelegate SharedManager()
    {
        if (sharedInstance == null)
        {
            sharedInstance = Appdelegate.Create();
        }
        return sharedInstance;
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
}
