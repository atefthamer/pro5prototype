using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTargetController : MonoBehaviour
{
    [HideInInspector]
    public TargetManager tMan;
    [HideInInspector]
    public LauncherManager lMan;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") && tMan.targetHittable == true)
        {
            tMan.score++;
            tMan.targetDestroyed = true;
            Destroy(this.gameObject);
            tMan.targetsHit = false;

            if (tMan.score < 5)
            {
                Debug.Log("NEXT LAUNCHER");
                lMan.NextLauncher();
            }
        }
    }
}
