using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public TargetManager tMan;

    private void Update()
    {
        if (tMan.incorrect == true)
        {
            DisableHalo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile") && tMan.firstTarget == null)
        {
            tMan.firstTarget = this.gameObject;
            Debug.Log("FIRST TARGET = " + tMan.firstTarget);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("projectile") && tMan.firstTarget != null && this.gameObject != tMan.firstTarget)
        {
            tMan.secondTarget = this.gameObject;
            Debug.Log("SECOND TARGET = " + tMan.secondTarget);
            tMan.targetsHit = true;
        }

        if (other.gameObject.CompareTag("Interactable") && this.gameObject == tMan.firstTarget)
        {
            Destroy(this.gameObject);
            tMan.firstTarget = null;
        }

        if (other.gameObject.CompareTag("Interactable") && this.gameObject == tMan.secondTarget)
        {
            Destroy(this.gameObject);
            tMan.secondTarget = null;
        }
    }

    private void DisableHalo()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        tMan.incorrect = false;
        Debug.Log(tMan.incorrect);
    }
}
