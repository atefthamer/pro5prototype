using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HITandSave : MonoBehaviour
{
    // Start is called before the first frame update

    public List<int> destroyed = new List<int>();

    LoadLetters load;

    //public GameObject obj;

    void Start()
    {
        load = new LoadLetters();
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
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            load.CheckForDestroyedLetter();
        }
    }
}
