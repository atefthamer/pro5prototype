using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;


public class ChangeScene : UIElement
{
    //private AssetBundle myLoadedAssetBundle;
    //private string[] scenePaths;
    //public SceneSwitch sw;
    //SceneManager mng;
    
    protected override void Awake()
    {
        base.Awake();

        //ui = this.GetComponentInParent<SkeletonUIOptions>();
        //sw = this.GetComponent<SceneSwitch>();
        //mng = new SceneManager();
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        //SceneManager.LoadScene()
        //if(sw != null)
        //{
        //    sw.SceneSwitcher(1);
        //}
       SceneManager.LoadScene(1);
    }
}
