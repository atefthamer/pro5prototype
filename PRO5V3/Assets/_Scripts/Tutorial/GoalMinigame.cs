using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMinigame : MonoBehaviour
{
    public GameObject[] goals;
    GameObject currentGoal;
    int index;

    void Start()
    {
        index = Random.Range(0, goals.Length);
        currentGoal = goals[index];
        goals[index].SetActive(true);
        print(currentGoal.name);
    }

    public void NextGoal()
    {
        foreach (GameObject obj in goals)
        {
            obj.SetActive(false);
        }

        index = Random.Range(0, goals.Length);
        currentGoal = goals[index];
        goals[index].SetActive(true);
        print(currentGoal.name);
    }

    public void gameFinished()
    {
        foreach (GameObject obj in goals)
        {
            obj.SetActive(false);
        }
    }
}
