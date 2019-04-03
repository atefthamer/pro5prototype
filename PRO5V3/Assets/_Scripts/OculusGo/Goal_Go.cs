using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Go : MonoBehaviour
{
    public Reticule ret;
    public Tutorial_Minigame nextTarget;
    public Trigger_Minigame trigger;

    public void Pressed()
    {
        if (nextTarget.startMinigame == false)
        {
            ret.Explode();
            nextTarget.NextTarget();
            nextTarget.startMinigame = true;
            trigger.TriggerMinigame();
        }
        else if (true)
        {
            ret.Explode();
            nextTarget.NextTarget();
            nextTarget.score++;
        }
    }
}
