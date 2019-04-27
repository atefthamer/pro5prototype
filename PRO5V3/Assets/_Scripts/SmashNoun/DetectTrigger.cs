using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmashNoun
{


    public class DetectTrigger : MonoBehaviour
    {
        public SmashNounSFX sfx;

        [SerializeField]
        public string ObjectTag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Hammer"))
            {
                UnitDeathEventInfo udei = new UnitDeathEventInfo();
                udei.EventDescription = "Unit " + gameObject.name + " has died.";
                udei.UnitGO = gameObject;
                Debug.Log("It just works " + udei.UnitGO.name);
                EventSystem.Current.FireEvent(udei);
            }
        }
        // private void OnTriggerEnter(Collider other)
        // {
        //     if (other.gameObject.CompareTag("Barrel"))
        //     {
        //         Debug.Log("COLLISION DETECTED");
        //         sfx.DestroyBarrel();
        //         Destroy(other.gameObject);
        //     }
        // }
    }

}
