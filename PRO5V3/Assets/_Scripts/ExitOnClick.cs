using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ExitOnClick : MonoBehaviour {
    public void Quit ()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}