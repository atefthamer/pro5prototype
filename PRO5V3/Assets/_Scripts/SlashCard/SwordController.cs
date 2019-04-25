using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public void ChargeSword()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void UnchargeSword()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
