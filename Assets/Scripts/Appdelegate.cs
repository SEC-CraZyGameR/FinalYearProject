using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appdelegate
{
    public static Appdelegate SharedInstance = null;

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
}
