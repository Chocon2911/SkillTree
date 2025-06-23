using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawner : Spawner
{
    private static UISpawner instance;
    public static UISpawner Instance => instance;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("One UISpawner only", gameObject);
            return;
        }

        instance = this;
        base.Awake();
    }
}
