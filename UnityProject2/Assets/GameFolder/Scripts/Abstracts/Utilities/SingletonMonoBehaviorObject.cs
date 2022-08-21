using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject2.Abstracts.Utilities{
public abstract class SingletonMonoBehaviorObject <T> : MonoBehaviour where T: Component
{
    public static T Instance {get; private set;}

    protected void SingletonThisObject(T entitiy){
    if(Instance == null)
    {
        Instance = entitiy;
        DontDestroyOnLoad(this.gameObject);
    }
    else
    {
        Destroy(this.gameObject);
    }
    }
}
}