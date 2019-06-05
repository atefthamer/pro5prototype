using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [HideInInspector]
    public TargetManager tMan;
    [HideInInspector]
    public LauncherManager lMan;
    [HideInInspector]
    public ShieldController sCon;

    // CODE FOR CARDS IN CIRCLE
    //[HideInInspector]
    //public Transform lookPoint = null;

    //private void Start()
    //{
    //    transform.LookAt(lookPoint);
    //    transform.Rotate(new Vector3(0, 180, 0));
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile") && tMan.firstTarget == null)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            tMan.firstTarget = this.gameObject;
            Debug.Log("FIRST TARGET = " + tMan.firstTarget);
            // Makes it so cards turn to player after hit
            this.gameObject.transform.Rotate(0, 180, 0);
            Destroy(other.gameObject);
            sCon.currentProjectile = null;
            sCon.fired = false;
            Debug.Log("NEXT LAUNCHER");
            lMan.NextLauncher();
        }
        else if (other.gameObject.CompareTag("projectile") && tMan.firstTarget != null && this.gameObject != tMan.firstTarget)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            tMan.secondTarget = this.gameObject;
            Debug.Log("SECOND TARGET = " + tMan.secondTarget);
            tMan.targetsHit = true;
            Destroy(other.gameObject);
            sCon.currentProjectile = null;
            sCon.fired = false;
            // Makes it so cards turn to player after hit
            this.gameObject.transform.Rotate(0, 180, 0);
        }
    }
}
