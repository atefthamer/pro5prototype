using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCategory : MonoBehaviour
{
    public GameObject[] categories;

    public void ShowCategories()
    {
        foreach (GameObject obj in categories)
        {
            obj.SetActive(true);
        }
    }
}
