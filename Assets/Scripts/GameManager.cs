using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool walking = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
