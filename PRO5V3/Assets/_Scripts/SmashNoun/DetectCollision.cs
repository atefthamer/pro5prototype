using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmashNoun
{
    public class DetectCollision : MonoBehaviour
    {
        public string ObjectName = "JudgeGavel";
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == ObjectName)
            {
                Destroy(this.gameObject);
            }
            Debug.Log("COLLISION OBJECT " + col.gameObject.name);

            UnitDeathEventInfo udei = new UnitDeathEventInfo();
            udei.EventDescription = "Unit " + gameObject.name + " has died.";
            udei.UnitGO = gameObject;
            Debug.Log("It just works " + udei.UnitGO.name);
            EventSystem.Current.FireEvent(udei);
        }

    }
}