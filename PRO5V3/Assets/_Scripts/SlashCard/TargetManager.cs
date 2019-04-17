using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject firstTarget = null;
    [HideInInspector]
    public GameObject secondTarget = null;
    [HideInInspector]
    public bool incorrect = false;
    [HideInInspector]
    public bool targetsHit = false;

    public GameObject player;
    public float speed = 1.0f;

    void Update()
    {
        if (targetsHit == true)
        {
            if (firstTarget.name == secondTarget.name)
            {
                float shot = speed * Time.deltaTime;
                firstTarget.transform.position = Vector3.MoveTowards(firstTarget.transform.position, player.transform.position, shot);
                secondTarget.transform.position = Vector3.MoveTowards(secondTarget.transform.position, player.transform.position, shot);

                if (Vector3.Distance(firstTarget.transform.position, player.transform.position) < 1.0f && (Vector3.Distance(secondTarget.transform.position, player.transform.position) < 2.0f))
                {
                    
                }

            }
            else if (firstTarget.name != secondTarget.name)
            {
                incorrect = true;
                targetsHit = false;
                firstTarget = null;
                secondTarget = null;
            }
        }
    }
}
