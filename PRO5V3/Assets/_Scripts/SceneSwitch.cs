using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class SceneSwitch : UIElement
{
    [SerializeField]
    private GameObject player;

    private bool destroy = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        destroy = false;
        Debug.Log(player);
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public void DestroyPlayer(int sceneIndex)
    {
        Destroy(player);
        destroy = true;

        if (destroy == true)
        {
            destroy = false;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
    }
}