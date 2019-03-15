using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HITandSave : MonoBehaviour
{
    // Start is called before the first frame update

    // public List<int> destroyed = new List<int>();

    public int[] destroyedID = new int[1];

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
            destroyed.Add(this.gameObject.GetInstanceID());
            //destroyedID[0] = this.gameObject.GetInstanceID();
            //Destroy(this.gameObject);
            hit = true;
            //Destroy(other.gameObject);
        }
    }
}
