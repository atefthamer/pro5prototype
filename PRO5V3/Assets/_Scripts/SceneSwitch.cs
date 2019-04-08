using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class SceneSwitch : UIElement
{
    [SerializeField]
    private readonly GameObject player;

    private void Start()
    {
        Debug.Log(player);
    }

    protected override void Awake()
    {
        base.Awake();

        //ui = this.GetComponentInParent<SkeletonUIOptions>();
        //sw = this.GetComponent<SceneSwitch>();
        //mng = new SceneManager();
    }

    public void DestroyPlayer()
    {
        Destroy(player);
        SceneManager.LoadScene(1);
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        //SceneManager.LoadScene()
        //if(sw != null)
        //{
        //    sw.SceneSwitcher(1);
        //}


    }

    //public void SceneSwitcher (int sceneIndex)
    //{
    //    Destroy(player);
    //    SceneManager.LoadScene (sceneIndex);
    //}
}