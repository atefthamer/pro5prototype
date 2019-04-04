using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageShow : MonoBehaviour
{
    //public SpriteRenderer sp;

    public string imagesource = "";
   
    void Start()
    {
        this.gameObject.AddComponent<SpriteRenderer>();
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = ;
       
    }

    void Update()
    {

    }
}