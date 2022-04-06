using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T : Manager<T>
{
    public static T Instance;
    private void Awake() => Instance = (T)this;
}
