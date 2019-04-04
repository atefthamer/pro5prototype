using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial_Minigame : MonoBehaviour
{
    public SceneSwitch sw;
    public GameObject[] targets;
    GameObject currentTarget;
    int index;

    [HideInInspector]
    public float gameTimer = 90.0f;
    [HideInInspector]
    public bool startMinigame = false;

    [HideInInspector]
    public int score = 0;

    private void Start()
    {

    }

    void Update()
    {

        if (startMinigame == true)
        {
            gameTimer -= Time.deltaTime;

            if (gameTimer <= 0.0f)
            {
                gameTimer = 0.0f;
                GameFinished();
            }
        }
    }

    public void NextTarget()
    {
        foreach (GameObject obj in targets)
        {
            obj.SetActive(false);
        }

        index = Random.Range(0, targets.Length);
        currentTarget = targets[index];
        targets[index].SetActive(true);
        print(currentTarget.name);
    }

    public void GameFinished()
    {
        foreach (GameObject obj in targets)
        {
            obj.SetActive(false);
        }

        sw.SceneSwitcher(2);
    }
}
