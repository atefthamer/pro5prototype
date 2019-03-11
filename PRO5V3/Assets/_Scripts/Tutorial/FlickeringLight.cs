using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light goalLight;

    void Start()
    {
        goalLight = GetComponent<Light>();
    }

    IEnumerator Flashing ()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            goalLight.enabled = !goalLight.enabled;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Flashing());
    }
}
