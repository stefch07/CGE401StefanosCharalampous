using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance; // Single declaration of instance field

    public static T Instance // Property with correct spelling
    {
        get { return instance; }
    }

    public static bool IsInitialized
    {
        get {return instance != null;}
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a second instance of a singleton class.");
            Destroy(this);
        }
        else
        {
            instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}