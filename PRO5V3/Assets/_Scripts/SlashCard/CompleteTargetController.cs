using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTargetController : MonoBehaviour
{
    [HideInInspector]
    public TargetManager tMan;
    //[HideInInspector]
    //public LauncherManager lMan;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") && tMan.targetHittable == true)
        {
            tMan.targetDestroyed = true;
            Destroy(this.gameObject);
            tMan.targetsHit = false;
            //tMan.firstTarget = null;
        }

        //if (other.gameObject.CompareTag("Interactable") && this.gameObject == tMan.secondTarget && tMan.targetHittable == true)
        //{
        //    tMan.secondHit = true;
        //    Destroy(this.gameObject);
        //    tMan.targetsHit = false;
        //    //tMan.secondTarget = null;
        //}
    }
}
