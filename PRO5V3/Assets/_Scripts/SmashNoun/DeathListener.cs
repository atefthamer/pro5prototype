using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class DeathListener : MonoBehaviour
    {
        //PlaySound pl;
        // Use this for initialization
        void Start()
        {
            EventSystem.Current.RegisterListener<UnitDeathEventInfo>(OnUnitDied);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnUnitDied(UnitDeathEventInfo unitDeathInfo)
        {
            Debug.Log("Alerted about unit death: " + unitDeathInfo.UnitGO.name);
            //pl.playTheDamnSound();
            //unitDeathInfo.UnitGO.gameObject.GetComponent<PlaySound>().PlayTheDamnSound();
            PlaySound playSound = unitDeathInfo.UnitGO.gameObject.GetComponent<PlaySound>();
            if (playSound != null)
            {
                playSound.PlayTheDamnSound();
            }

            Destroy(unitDeathInfo.UnitGO, playSound.audioData.clip.length);
        }
    }
}