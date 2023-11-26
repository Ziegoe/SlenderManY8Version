using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Jumpscare : MonoBehaviour
{
    public float lenght = 10;
    public static Jumpscare inst;
    public void Awake()
    {
        if (inst == null) inst = this;
        else Destroy(gameObject);
    }

    public void Show()
    {
         
    }

   
    void Restart()
    {
        
    }
}
