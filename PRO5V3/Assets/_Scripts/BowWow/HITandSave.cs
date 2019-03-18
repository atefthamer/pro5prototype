using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HITandSave : MonoBehaviour
{
    // Start is called before the first frame update

    // public List<int> destroyed = new List<int>();

    public int objectId = 0;
    public GameObject arrow;
    public bool hit = false;

    //LoadLetters load;

    //public GameObject obj;
    LoadLetters load = new LoadLetters();
    public HITandSave()
    {
        
    }

    void Start()
    {
        //load = new LoadLetters();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            Debug.Log("Letter Hit");
            //Destroy(other.gameObject);
            arrow = other.gameObject;
            hit = true;
            objectId = this.gameObject.GetInstanceID();          
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("projectile"))
    //    {
    //        Debug.Log("Letter Hit");
    //        //Destroy(other.gameObject);
    //        arrow = collision.gameObject;
    //        hit = true;
    //        objectId = this.gameObject.GetInstanceID();
    //    }
    //}
}
