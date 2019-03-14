using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HITandSave : MonoBehaviour
{
    // Start is called before the first frame update

    // public List<int> destroyed = new List<int>();


    //[SerializeField]
    // GameObject load = null;
    //public GameObject obj;
    LoadLetters load = new LoadLetters();
    public HITandSave()
    {
        
    }

    void Start()
    {
       
        //gameObject.GetComponent<LoadLetters>
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
            //load.AddDestroyedObject();
            //load.CheckForDestroyedLetter();
            load.GetList().Add(this.gameObject.GetInstanceID());
            Debug.Log("LIST SIZE " + load.GetList().Count);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
