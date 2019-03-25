using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public bool isStart = true;
    public bool isLoad = true;
    public bool isPrefs = true;
    public bool isQuit = true;
    void OnMouseUp()
    {
        //if (isStart)
        //{
        //    Application.LoadLevel(1);
        //}
        //else
        //{
        //    Application.Quit();
        //}
        //if (isQuit)
        //{
            
        //}
        ChangeState(isStart, 1);
    }

    void ChangeState(bool state ,int x)
    {
        if (state)
        {
            Application.LoadLevel(x);
        }
        else
        {
            Application.Quit();
        }
       
    }
}