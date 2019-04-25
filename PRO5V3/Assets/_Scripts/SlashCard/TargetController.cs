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
    public Transform lookPoint = null;

    private void Start()
    {
        transform.LookAt(lookPoint);
        transform.Rotate(new Vector3(0, 90, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile") && tMan.firstTarget == null)
        {
            tMan.firstTarget = this.gameObject;
            Debug.Log("FIRST TARGET = " + tMan.firstTarget);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //lMan.NextLauncher();
            //Destroy(other);
        }
        else if (other.gameObject.CompareTag("projectile") && tMan.firstTarget != null && this.gameObject != tMan.firstTarget)
        {
            tMan.secondTarget = this.gameObject;
            Debug.Log("SECOND TARGET = " + tMan.secondTarget);
            tMan.targetsHit = true;
            //lMan.NextLauncher();
            //Destroy(other);
        }

        if (other.gameObject.CompareTag("Interactable") && this.gameObject == tMan.firstTarget && tMan.correct == true)
        {
            tMan.firstHit = true;
            Destroy(this.gameObject);
            tMan.firstTarget = null;
        }

        if (other.gameObject.CompareTag("Interactable") && this.gameObject == tMan.secondTarget && tMan.correct == true)
        {
            tMan.secondHit = true;
            Destroy(this.gameObject);
            tMan.secondTarget = null;
        }
    }
}
