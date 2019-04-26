using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmashNoun
{


    public class DetectTrigger : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Barrel"))
            {
                UnitDeathEventInfo udei = new UnitDeathEventInfo();
                udei.EventDescription = "Unit " + gameObject.name + " has died.";
                udei.UnitGO = gameObject;
                Debug.Log("It just works " + udei.UnitGO.name);
                EventSystem.Current.FireEvent(udei);
            }
        }
    }

}
